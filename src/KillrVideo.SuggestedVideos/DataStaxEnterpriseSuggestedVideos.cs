using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Cassandra;
using Google.Protobuf.Reflection;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using KillrVideo.Cassandra;
using KillrVideo.Host.ServiceDiscovery;
using KillrVideo.Protobuf;
using KillrVideo.Protobuf.Services;
using KillrVideo.SuggestedVideos.MLT;
using RestSharp;

namespace KillrVideo.SuggestedVideos
{
    /// <summary>
    /// Makes video suggestions based on data in Cassandra.
    /// </summary>
    [Export(typeof(IGrpcServerService))]
    public class DataStaxEnterpriseSuggestedVideos : SuggestedVideoService.SuggestedVideoServiceBase, IConditionalGrpcServerService
    {
        private readonly ISession _session;
        private readonly Func<Uri, IRestClient> _createRestClient;
        private readonly SuggestionsOptions _options;
        private readonly PreparedStatementCache _statementCache;
        private readonly IFindServices _serviceDiscovery;

        private Task<Uri> _dseSearchUri;

        public ServiceDescriptor Descriptor => SuggestedVideoService.Descriptor;

        public DataStaxEnterpriseSuggestedVideos(ISession session, PreparedStatementCache statementCache,
                                                 IFindServices serviceDiscovery, Func<Uri, IRestClient> createRestClient,
                                                 SuggestionsOptions options)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));
            if (statementCache == null) throw new ArgumentNullException(nameof(statementCache));
            if (serviceDiscovery == null) throw new ArgumentNullException(nameof(serviceDiscovery));
            if (createRestClient == null) throw new ArgumentNullException(nameof(createRestClient));
            if (options == null) throw new ArgumentNullException(nameof(options));
            _session = session;
            _statementCache = statementCache;
            _serviceDiscovery = serviceDiscovery;
            _createRestClient = createRestClient;
            _options = options;
            _dseSearchUri = null;
        }

        /// <summary>
        /// Convert this instance to a ServerServiceDefinition that can be run on a Grpc server.
        /// </summary>
        public ServerServiceDefinition ToServerServiceDefinition()
        {
            return SuggestedVideoService.BindService(this);
        }

        /// <summary>
        /// Returns true if this service should run given the configuration of the host.
        /// </summary>
        public bool ShouldRun()
        {
            // Use this implementation when DSE Search and Spark are enabled in the host config
            return _options.DseEnabled;
        }

        /// <summary>
        /// Gets the first 5 videos related to the specified video.
        /// </summary>
        public override async Task<GetRelatedVideosResponse> GetRelatedVideos(GetRelatedVideosRequest request, ServerCallContext context)
        {
            // Get REST client for dse-search service
            Uri searchUri = await GetDseSearchUri().ConfigureAwait(false);
            IRestClient restClient = _createRestClient(searchUri);

            // Example request: http://127.0.2.15:8983/solr/killrvideo.videos/mlt?q=videoid%3Asome-uuid&wt=json&indent=true&qt=mlt&mlt.fl=name&mlt.mindf=1&mlt.mintf=1
            var solrRequest = new RestRequest("killrvideo.videos/mlt");
            solrRequest.AddParameter("q", $"videoid:\"{request.VideoId.Value}\"");
            solrRequest.AddParameter("wt", "json");

            // Paging information
            int start;
            if (request.PagingState == null || int.TryParse(request.PagingState, out start) == false)
                start = 0;

            solrRequest.AddParameter("start", start);
            solrRequest.AddParameter("rows", request.PageSize);

            //MLT Fields to Consider
            solrRequest.AddParameter("mlt.fl", "name,description,tags");

            //MLT Minimum Document Frequency - the frequency at which words will be ignored which do not occur in at least this many docs.
            solrRequest.AddParameter("mlt.mindf", 2);

            //MLT Minimum Term Frequency - the frequency below which terms will be ignored in the source doc.
            solrRequest.AddParameter("mlt.mintf", 2);

            IRestResponse<MLTQueryResult> solrResponse = await restClient.ExecuteTaskAsync<MLTQueryResult>(solrRequest).ConfigureAwait(false);

            // Start with an empty response
            var response = new GetRelatedVideosResponse { VideoId = request.VideoId };

            // Check for network/timeout errors
            if (solrResponse.ResponseStatus != ResponseStatus.Completed)
            {
                // TODO: Logger.Error(response.ErrorException, "Error while querying Solr video suggestions from {host} for {query}", nodeIp, query);
                return response;
            }

            // Check for HTTP error codes
            if (solrResponse.StatusCode != HttpStatusCode.OK)
            {
                // TODO: Logger.Error("HTTP status code {code} while querying Solr video suggestions from {host} for {query}", (int) response.StatusCode, nodeIp, query);
                return response;
            }

            // Success
            int nextPageStartIndex = solrResponse.Data.Response.Start + solrResponse.Data.Response.Docs.Count;
            string pagingState = nextPageStartIndex == solrResponse.Data.Response.NumFound ? "" : nextPageStartIndex.ToString();
            response.PagingState = pagingState;
            response.Videos.Add(solrResponse.Data.Response.Docs.Select(doc => new SuggestedVideoPreview
            {
                VideoId = doc.VideoId.ToUuid(),
                AddedDate = doc.AddedDate.ToTimestamp(),
                Name = doc.Name,
                PreviewImageLocation = doc.PreviewImageLocation,
                UserId = doc.UserId.ToUuid()
            }));
            return response;
        }

        /// <summary>
        /// Gets the personalized video suggestions for a specific user.
        /// </summary>
        public override async Task<GetSuggestedForUserResponse> GetSuggestedForUser(GetSuggestedForUserRequest request, ServerCallContext context)
        {
            // Return the output of a Spark job that runs periodically in the background to populate the video_recommendations table
            // (see the /data/spark folder in the repo for more information)
            PreparedStatement prepared = await _statementCache.GetOrAddAsync(
                "SELECT videoid, authorid, name, added_date, preview_image_location FROM video_recommendations WHERE userid=?");

            IStatement bound = prepared.Bind(request.UserId.ToGuid())
                                       .SetAutoPage(false)
                                       .SetPageSize(request.PageSize);

            // The initial query won't have a paging state, but subsequent calls should if there are more pages
            if (string.IsNullOrEmpty(request.PagingState) == false)
                bound.SetPagingState(Convert.FromBase64String(request.PagingState));

            RowSet rows = await _session.ExecuteAsync(bound).ConfigureAwait(false);

            var response = new GetSuggestedForUserResponse
            {
                UserId = request.UserId,
                PagingState = rows.PagingState != null && rows.PagingState.Length > 0 ? Convert.ToBase64String(rows.PagingState) : ""
            };
            response.Videos.Add(rows.Select(MapRowToVideoPreview));
            return response;
        }

        private Task<Uri> GetDseSearchUri()
        {
            // Try to minimize the number of times we lookup the search service by caching and reusing the task
            Task<Uri> uri = _dseSearchUri;
            if (uri != null && uri.IsFaulted == false)
                return uri;

            // It's not the end of the world if we have a race here and multiple threads do lookups
            uri = LookupDseSearch();
            _dseSearchUri = uri;
            return uri;
        }

        private async Task<Uri> LookupDseSearch()
        {
            IEnumerable<string> ipAndPorts = await _serviceDiscovery.LookupServiceAsync("dse-search").ConfigureAwait(false);
            return new Uri($"http://{ipAndPorts.First()}/solr");
        }

        private static SuggestedVideoPreview MapRowToVideoPreview(Row row)
        {
            return new SuggestedVideoPreview
            {
                VideoId = row.GetValue<Guid>("videoid").ToUuid(),
                AddedDate = row.GetValue<DateTimeOffset>("added_date").ToTimestamp(),
                Name = row.GetValue<string>("name"),
                PreviewImageLocation = row.GetValue<string>("preview_image_location"),
                UserId = row.GetValue<Guid>("authorid").ToUuid()
            };
        }
    }
}