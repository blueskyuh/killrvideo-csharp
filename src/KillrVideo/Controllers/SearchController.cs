﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using KillrVideo.ActionFilters;
using KillrVideo.ActionResults;
using KillrVideo.Models.Search;
using KillrVideo.Models.Shared;
using KillrVideo.Search;
using KillrVideo.Search.Dtos;
using KillrVideo.Statistics;
using KillrVideo.Statistics.Dtos;
using KillrVideo.UserManagement;
using KillrVideo.UserManagement.Dtos;

namespace KillrVideo.Controllers
{
    public class SearchController : ConventionControllerBase
    {
        private readonly ISearchVideosByTag _searchService;
        private readonly IUserManagementService _userManagement;
        private readonly IStatisticsService _stats;

        public SearchController(ISearchVideosByTag searchService, IUserManagementService userManagement, IStatisticsService stats)
        {
            if (searchService == null) throw new ArgumentNullException("searchService");
            if (userManagement == null) throw new ArgumentNullException("userManagement");
            if (stats == null) throw new ArgumentNullException("stats");
            _searchService = searchService;
            _userManagement = userManagement;
            _stats = stats;
        }

        /// <summary>
        /// Shows the search results view.
        /// </summary>
        [HttpGet]
        public ViewResult Results(ShowSearchResultsViewModel model)
        {
            return View(model);
        }

        /// <summary>
        /// Searches videos and returns any results.
        /// </summary>
        [HttpPost]
        public async Task<JsonNetResult> Videos(SearchVideosViewModel model)
        {
            VideosByTag videos = await _searchService.GetVideosByTag(new GetVideosByTag
            {
                Tag = model.Tag,
                PageSize = model.PageSize,
                FirstVideoOnPageVideoId = model.FirstVideoOnPage == null ? (Guid?) null : model.FirstVideoOnPage.VideoId
            });

            // TODO:  Better solution than client-side JOINs
            var authorIds = new HashSet<Guid>(videos.Videos.Select(v => v.UserId));
            Task<IEnumerable<UserProfile>> authorsTask = _userManagement.GetUserProfiles(authorIds);

            var videoIds = new HashSet<Guid>(videos.Videos.Select(v => v.VideoId));
            Task<IEnumerable<PlayStats>> statsTask = _stats.GetNumberOfPlays(videoIds);

            await Task.WhenAll(authorsTask, statsTask);

            return JsonSuccess(new SearchResultsViewModel
            {
                Tag = model.Tag,
                Videos = videos.Videos
                               .Join(authorsTask.Result, vp => vp.UserId, a => a.UserId,
                                     (vp, a) => new { VideoPreview = vp, Author = a })
                               .Join(statsTask.Result, vpa => vpa.VideoPreview.VideoId, s => s.VideoId,
                                     (vpa, s) => VideoPreviewViewModel.FromDataModel(vpa.VideoPreview, vpa.Author, s, Url))
                               .ToList()
            });
        }

        /// <summary>
        /// Searches tags and returns tags suggestions.
        /// </summary>
        [HttpGet, NoCache]
        public async Task<JsonNetResult> SuggestTags(SuggestTagsViewModel model)
        {
            TagsStartingWith tagsStartingWith = await _searchService.GetTagsStartingWith(new GetTagsStartingWith
            {
                TagStartsWith = model.TagStart,
                PageSize = model.PageSize
            });

            return JsonSuccess(new TagResultsViewModel
            {
                TagStart = tagsStartingWith.TagStartsWith,
                Tags = tagsStartingWith.Tags
            });
        }
	}
}