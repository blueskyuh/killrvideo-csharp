// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: video-catalog/video_catalog_service.proto
#region Designer generated code

using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;

namespace KillrVideo.VideoCatalog {
  public static class VideoCatalogService
  {
    static readonly string __ServiceName = "killrvideo.video_catalog.VideoCatalogService";

    static readonly Marshaller<global::KillrVideo.VideoCatalog.SubmitUploadedVideoRequest> __Marshaller_SubmitUploadedVideoRequest = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::KillrVideo.VideoCatalog.SubmitUploadedVideoRequest.Parser.ParseFrom);
    static readonly Marshaller<global::KillrVideo.VideoCatalog.SubmitUploadedVideoResponse> __Marshaller_SubmitUploadedVideoResponse = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::KillrVideo.VideoCatalog.SubmitUploadedVideoResponse.Parser.ParseFrom);
    static readonly Marshaller<global::KillrVideo.VideoCatalog.SubmitYouTubeVideoRequest> __Marshaller_SubmitYouTubeVideoRequest = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::KillrVideo.VideoCatalog.SubmitYouTubeVideoRequest.Parser.ParseFrom);
    static readonly Marshaller<global::KillrVideo.VideoCatalog.SubmitYouTubeVideoResponse> __Marshaller_SubmitYouTubeVideoResponse = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::KillrVideo.VideoCatalog.SubmitYouTubeVideoResponse.Parser.ParseFrom);
    static readonly Marshaller<global::KillrVideo.VideoCatalog.GetVideoRequest> __Marshaller_GetVideoRequest = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::KillrVideo.VideoCatalog.GetVideoRequest.Parser.ParseFrom);
    static readonly Marshaller<global::KillrVideo.VideoCatalog.GetVideoResponse> __Marshaller_GetVideoResponse = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::KillrVideo.VideoCatalog.GetVideoResponse.Parser.ParseFrom);
    static readonly Marshaller<global::KillrVideo.VideoCatalog.GetVideoPreviewsRequest> __Marshaller_GetVideoPreviewsRequest = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::KillrVideo.VideoCatalog.GetVideoPreviewsRequest.Parser.ParseFrom);
    static readonly Marshaller<global::KillrVideo.VideoCatalog.GetVideoPreviewsResponse> __Marshaller_GetVideoPreviewsResponse = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::KillrVideo.VideoCatalog.GetVideoPreviewsResponse.Parser.ParseFrom);
    static readonly Marshaller<global::KillrVideo.VideoCatalog.GetLatestVideoPreviewsRequest> __Marshaller_GetLatestVideoPreviewsRequest = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::KillrVideo.VideoCatalog.GetLatestVideoPreviewsRequest.Parser.ParseFrom);
    static readonly Marshaller<global::KillrVideo.VideoCatalog.GetLatestVideoPreviewsResponse> __Marshaller_GetLatestVideoPreviewsResponse = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::KillrVideo.VideoCatalog.GetLatestVideoPreviewsResponse.Parser.ParseFrom);
    static readonly Marshaller<global::KillrVideo.VideoCatalog.GetUserVideoPreviewsRequest> __Marshaller_GetUserVideoPreviewsRequest = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::KillrVideo.VideoCatalog.GetUserVideoPreviewsRequest.Parser.ParseFrom);
    static readonly Marshaller<global::KillrVideo.VideoCatalog.GetUserVideoPreviewsResponse> __Marshaller_GetUserVideoPreviewsResponse = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::KillrVideo.VideoCatalog.GetUserVideoPreviewsResponse.Parser.ParseFrom);

    static readonly Method<global::KillrVideo.VideoCatalog.SubmitUploadedVideoRequest, global::KillrVideo.VideoCatalog.SubmitUploadedVideoResponse> __Method_SubmitUploadedVideo = new Method<global::KillrVideo.VideoCatalog.SubmitUploadedVideoRequest, global::KillrVideo.VideoCatalog.SubmitUploadedVideoResponse>(
        MethodType.Unary,
        __ServiceName,
        "SubmitUploadedVideo",
        __Marshaller_SubmitUploadedVideoRequest,
        __Marshaller_SubmitUploadedVideoResponse);

    static readonly Method<global::KillrVideo.VideoCatalog.SubmitYouTubeVideoRequest, global::KillrVideo.VideoCatalog.SubmitYouTubeVideoResponse> __Method_SubmitYouTubeVideo = new Method<global::KillrVideo.VideoCatalog.SubmitYouTubeVideoRequest, global::KillrVideo.VideoCatalog.SubmitYouTubeVideoResponse>(
        MethodType.Unary,
        __ServiceName,
        "SubmitYouTubeVideo",
        __Marshaller_SubmitYouTubeVideoRequest,
        __Marshaller_SubmitYouTubeVideoResponse);

    static readonly Method<global::KillrVideo.VideoCatalog.GetVideoRequest, global::KillrVideo.VideoCatalog.GetVideoResponse> __Method_GetVideo = new Method<global::KillrVideo.VideoCatalog.GetVideoRequest, global::KillrVideo.VideoCatalog.GetVideoResponse>(
        MethodType.Unary,
        __ServiceName,
        "GetVideo",
        __Marshaller_GetVideoRequest,
        __Marshaller_GetVideoResponse);

    static readonly Method<global::KillrVideo.VideoCatalog.GetVideoPreviewsRequest, global::KillrVideo.VideoCatalog.GetVideoPreviewsResponse> __Method_GetVideoPreviews = new Method<global::KillrVideo.VideoCatalog.GetVideoPreviewsRequest, global::KillrVideo.VideoCatalog.GetVideoPreviewsResponse>(
        MethodType.Unary,
        __ServiceName,
        "GetVideoPreviews",
        __Marshaller_GetVideoPreviewsRequest,
        __Marshaller_GetVideoPreviewsResponse);

    static readonly Method<global::KillrVideo.VideoCatalog.GetLatestVideoPreviewsRequest, global::KillrVideo.VideoCatalog.GetLatestVideoPreviewsResponse> __Method_GetLatestVideoPreviews = new Method<global::KillrVideo.VideoCatalog.GetLatestVideoPreviewsRequest, global::KillrVideo.VideoCatalog.GetLatestVideoPreviewsResponse>(
        MethodType.Unary,
        __ServiceName,
        "GetLatestVideoPreviews",
        __Marshaller_GetLatestVideoPreviewsRequest,
        __Marshaller_GetLatestVideoPreviewsResponse);

    static readonly Method<global::KillrVideo.VideoCatalog.GetUserVideoPreviewsRequest, global::KillrVideo.VideoCatalog.GetUserVideoPreviewsResponse> __Method_GetUserVideoPreviews = new Method<global::KillrVideo.VideoCatalog.GetUserVideoPreviewsRequest, global::KillrVideo.VideoCatalog.GetUserVideoPreviewsResponse>(
        MethodType.Unary,
        __ServiceName,
        "GetUserVideoPreviews",
        __Marshaller_GetUserVideoPreviewsRequest,
        __Marshaller_GetUserVideoPreviewsResponse);

    // service descriptor
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::KillrVideo.VideoCatalog.VideoCatalogServiceReflection.Descriptor.Services[0]; }
    }

    // client interface
    public interface IVideoCatalogServiceClient
    {
      global::KillrVideo.VideoCatalog.SubmitUploadedVideoResponse SubmitUploadedVideo(global::KillrVideo.VideoCatalog.SubmitUploadedVideoRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken));
      global::KillrVideo.VideoCatalog.SubmitUploadedVideoResponse SubmitUploadedVideo(global::KillrVideo.VideoCatalog.SubmitUploadedVideoRequest request, CallOptions options);
      AsyncUnaryCall<global::KillrVideo.VideoCatalog.SubmitUploadedVideoResponse> SubmitUploadedVideoAsync(global::KillrVideo.VideoCatalog.SubmitUploadedVideoRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken));
      AsyncUnaryCall<global::KillrVideo.VideoCatalog.SubmitUploadedVideoResponse> SubmitUploadedVideoAsync(global::KillrVideo.VideoCatalog.SubmitUploadedVideoRequest request, CallOptions options);
      global::KillrVideo.VideoCatalog.SubmitYouTubeVideoResponse SubmitYouTubeVideo(global::KillrVideo.VideoCatalog.SubmitYouTubeVideoRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken));
      global::KillrVideo.VideoCatalog.SubmitYouTubeVideoResponse SubmitYouTubeVideo(global::KillrVideo.VideoCatalog.SubmitYouTubeVideoRequest request, CallOptions options);
      AsyncUnaryCall<global::KillrVideo.VideoCatalog.SubmitYouTubeVideoResponse> SubmitYouTubeVideoAsync(global::KillrVideo.VideoCatalog.SubmitYouTubeVideoRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken));
      AsyncUnaryCall<global::KillrVideo.VideoCatalog.SubmitYouTubeVideoResponse> SubmitYouTubeVideoAsync(global::KillrVideo.VideoCatalog.SubmitYouTubeVideoRequest request, CallOptions options);
      global::KillrVideo.VideoCatalog.GetVideoResponse GetVideo(global::KillrVideo.VideoCatalog.GetVideoRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken));
      global::KillrVideo.VideoCatalog.GetVideoResponse GetVideo(global::KillrVideo.VideoCatalog.GetVideoRequest request, CallOptions options);
      AsyncUnaryCall<global::KillrVideo.VideoCatalog.GetVideoResponse> GetVideoAsync(global::KillrVideo.VideoCatalog.GetVideoRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken));
      AsyncUnaryCall<global::KillrVideo.VideoCatalog.GetVideoResponse> GetVideoAsync(global::KillrVideo.VideoCatalog.GetVideoRequest request, CallOptions options);
      global::KillrVideo.VideoCatalog.GetVideoPreviewsResponse GetVideoPreviews(global::KillrVideo.VideoCatalog.GetVideoPreviewsRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken));
      global::KillrVideo.VideoCatalog.GetVideoPreviewsResponse GetVideoPreviews(global::KillrVideo.VideoCatalog.GetVideoPreviewsRequest request, CallOptions options);
      AsyncUnaryCall<global::KillrVideo.VideoCatalog.GetVideoPreviewsResponse> GetVideoPreviewsAsync(global::KillrVideo.VideoCatalog.GetVideoPreviewsRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken));
      AsyncUnaryCall<global::KillrVideo.VideoCatalog.GetVideoPreviewsResponse> GetVideoPreviewsAsync(global::KillrVideo.VideoCatalog.GetVideoPreviewsRequest request, CallOptions options);
      global::KillrVideo.VideoCatalog.GetLatestVideoPreviewsResponse GetLatestVideoPreviews(global::KillrVideo.VideoCatalog.GetLatestVideoPreviewsRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken));
      global::KillrVideo.VideoCatalog.GetLatestVideoPreviewsResponse GetLatestVideoPreviews(global::KillrVideo.VideoCatalog.GetLatestVideoPreviewsRequest request, CallOptions options);
      AsyncUnaryCall<global::KillrVideo.VideoCatalog.GetLatestVideoPreviewsResponse> GetLatestVideoPreviewsAsync(global::KillrVideo.VideoCatalog.GetLatestVideoPreviewsRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken));
      AsyncUnaryCall<global::KillrVideo.VideoCatalog.GetLatestVideoPreviewsResponse> GetLatestVideoPreviewsAsync(global::KillrVideo.VideoCatalog.GetLatestVideoPreviewsRequest request, CallOptions options);
      global::KillrVideo.VideoCatalog.GetUserVideoPreviewsResponse GetUserVideoPreviews(global::KillrVideo.VideoCatalog.GetUserVideoPreviewsRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken));
      global::KillrVideo.VideoCatalog.GetUserVideoPreviewsResponse GetUserVideoPreviews(global::KillrVideo.VideoCatalog.GetUserVideoPreviewsRequest request, CallOptions options);
      AsyncUnaryCall<global::KillrVideo.VideoCatalog.GetUserVideoPreviewsResponse> GetUserVideoPreviewsAsync(global::KillrVideo.VideoCatalog.GetUserVideoPreviewsRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken));
      AsyncUnaryCall<global::KillrVideo.VideoCatalog.GetUserVideoPreviewsResponse> GetUserVideoPreviewsAsync(global::KillrVideo.VideoCatalog.GetUserVideoPreviewsRequest request, CallOptions options);
    }

    // server-side interface
    public interface IVideoCatalogService
    {
      Task<global::KillrVideo.VideoCatalog.SubmitUploadedVideoResponse> SubmitUploadedVideo(global::KillrVideo.VideoCatalog.SubmitUploadedVideoRequest request, ServerCallContext context);
      Task<global::KillrVideo.VideoCatalog.SubmitYouTubeVideoResponse> SubmitYouTubeVideo(global::KillrVideo.VideoCatalog.SubmitYouTubeVideoRequest request, ServerCallContext context);
      Task<global::KillrVideo.VideoCatalog.GetVideoResponse> GetVideo(global::KillrVideo.VideoCatalog.GetVideoRequest request, ServerCallContext context);
      Task<global::KillrVideo.VideoCatalog.GetVideoPreviewsResponse> GetVideoPreviews(global::KillrVideo.VideoCatalog.GetVideoPreviewsRequest request, ServerCallContext context);
      Task<global::KillrVideo.VideoCatalog.GetLatestVideoPreviewsResponse> GetLatestVideoPreviews(global::KillrVideo.VideoCatalog.GetLatestVideoPreviewsRequest request, ServerCallContext context);
      Task<global::KillrVideo.VideoCatalog.GetUserVideoPreviewsResponse> GetUserVideoPreviews(global::KillrVideo.VideoCatalog.GetUserVideoPreviewsRequest request, ServerCallContext context);
    }

    // client stub
    public class VideoCatalogServiceClient : ClientBase, IVideoCatalogServiceClient
    {
      public VideoCatalogServiceClient(Channel channel) : base(channel)
      {
      }
      public global::KillrVideo.VideoCatalog.SubmitUploadedVideoResponse SubmitUploadedVideo(global::KillrVideo.VideoCatalog.SubmitUploadedVideoRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        var call = CreateCall(__Method_SubmitUploadedVideo, new CallOptions(headers, deadline, cancellationToken));
        return Calls.BlockingUnaryCall(call, request);
      }
      public global::KillrVideo.VideoCatalog.SubmitUploadedVideoResponse SubmitUploadedVideo(global::KillrVideo.VideoCatalog.SubmitUploadedVideoRequest request, CallOptions options)
      {
        var call = CreateCall(__Method_SubmitUploadedVideo, options);
        return Calls.BlockingUnaryCall(call, request);
      }
      public AsyncUnaryCall<global::KillrVideo.VideoCatalog.SubmitUploadedVideoResponse> SubmitUploadedVideoAsync(global::KillrVideo.VideoCatalog.SubmitUploadedVideoRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        var call = CreateCall(__Method_SubmitUploadedVideo, new CallOptions(headers, deadline, cancellationToken));
        return Calls.AsyncUnaryCall(call, request);
      }
      public AsyncUnaryCall<global::KillrVideo.VideoCatalog.SubmitUploadedVideoResponse> SubmitUploadedVideoAsync(global::KillrVideo.VideoCatalog.SubmitUploadedVideoRequest request, CallOptions options)
      {
        var call = CreateCall(__Method_SubmitUploadedVideo, options);
        return Calls.AsyncUnaryCall(call, request);
      }
      public global::KillrVideo.VideoCatalog.SubmitYouTubeVideoResponse SubmitYouTubeVideo(global::KillrVideo.VideoCatalog.SubmitYouTubeVideoRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        var call = CreateCall(__Method_SubmitYouTubeVideo, new CallOptions(headers, deadline, cancellationToken));
        return Calls.BlockingUnaryCall(call, request);
      }
      public global::KillrVideo.VideoCatalog.SubmitYouTubeVideoResponse SubmitYouTubeVideo(global::KillrVideo.VideoCatalog.SubmitYouTubeVideoRequest request, CallOptions options)
      {
        var call = CreateCall(__Method_SubmitYouTubeVideo, options);
        return Calls.BlockingUnaryCall(call, request);
      }
      public AsyncUnaryCall<global::KillrVideo.VideoCatalog.SubmitYouTubeVideoResponse> SubmitYouTubeVideoAsync(global::KillrVideo.VideoCatalog.SubmitYouTubeVideoRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        var call = CreateCall(__Method_SubmitYouTubeVideo, new CallOptions(headers, deadline, cancellationToken));
        return Calls.AsyncUnaryCall(call, request);
      }
      public AsyncUnaryCall<global::KillrVideo.VideoCatalog.SubmitYouTubeVideoResponse> SubmitYouTubeVideoAsync(global::KillrVideo.VideoCatalog.SubmitYouTubeVideoRequest request, CallOptions options)
      {
        var call = CreateCall(__Method_SubmitYouTubeVideo, options);
        return Calls.AsyncUnaryCall(call, request);
      }
      public global::KillrVideo.VideoCatalog.GetVideoResponse GetVideo(global::KillrVideo.VideoCatalog.GetVideoRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        var call = CreateCall(__Method_GetVideo, new CallOptions(headers, deadline, cancellationToken));
        return Calls.BlockingUnaryCall(call, request);
      }
      public global::KillrVideo.VideoCatalog.GetVideoResponse GetVideo(global::KillrVideo.VideoCatalog.GetVideoRequest request, CallOptions options)
      {
        var call = CreateCall(__Method_GetVideo, options);
        return Calls.BlockingUnaryCall(call, request);
      }
      public AsyncUnaryCall<global::KillrVideo.VideoCatalog.GetVideoResponse> GetVideoAsync(global::KillrVideo.VideoCatalog.GetVideoRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        var call = CreateCall(__Method_GetVideo, new CallOptions(headers, deadline, cancellationToken));
        return Calls.AsyncUnaryCall(call, request);
      }
      public AsyncUnaryCall<global::KillrVideo.VideoCatalog.GetVideoResponse> GetVideoAsync(global::KillrVideo.VideoCatalog.GetVideoRequest request, CallOptions options)
      {
        var call = CreateCall(__Method_GetVideo, options);
        return Calls.AsyncUnaryCall(call, request);
      }
      public global::KillrVideo.VideoCatalog.GetVideoPreviewsResponse GetVideoPreviews(global::KillrVideo.VideoCatalog.GetVideoPreviewsRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        var call = CreateCall(__Method_GetVideoPreviews, new CallOptions(headers, deadline, cancellationToken));
        return Calls.BlockingUnaryCall(call, request);
      }
      public global::KillrVideo.VideoCatalog.GetVideoPreviewsResponse GetVideoPreviews(global::KillrVideo.VideoCatalog.GetVideoPreviewsRequest request, CallOptions options)
      {
        var call = CreateCall(__Method_GetVideoPreviews, options);
        return Calls.BlockingUnaryCall(call, request);
      }
      public AsyncUnaryCall<global::KillrVideo.VideoCatalog.GetVideoPreviewsResponse> GetVideoPreviewsAsync(global::KillrVideo.VideoCatalog.GetVideoPreviewsRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        var call = CreateCall(__Method_GetVideoPreviews, new CallOptions(headers, deadline, cancellationToken));
        return Calls.AsyncUnaryCall(call, request);
      }
      public AsyncUnaryCall<global::KillrVideo.VideoCatalog.GetVideoPreviewsResponse> GetVideoPreviewsAsync(global::KillrVideo.VideoCatalog.GetVideoPreviewsRequest request, CallOptions options)
      {
        var call = CreateCall(__Method_GetVideoPreviews, options);
        return Calls.AsyncUnaryCall(call, request);
      }
      public global::KillrVideo.VideoCatalog.GetLatestVideoPreviewsResponse GetLatestVideoPreviews(global::KillrVideo.VideoCatalog.GetLatestVideoPreviewsRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        var call = CreateCall(__Method_GetLatestVideoPreviews, new CallOptions(headers, deadline, cancellationToken));
        return Calls.BlockingUnaryCall(call, request);
      }
      public global::KillrVideo.VideoCatalog.GetLatestVideoPreviewsResponse GetLatestVideoPreviews(global::KillrVideo.VideoCatalog.GetLatestVideoPreviewsRequest request, CallOptions options)
      {
        var call = CreateCall(__Method_GetLatestVideoPreviews, options);
        return Calls.BlockingUnaryCall(call, request);
      }
      public AsyncUnaryCall<global::KillrVideo.VideoCatalog.GetLatestVideoPreviewsResponse> GetLatestVideoPreviewsAsync(global::KillrVideo.VideoCatalog.GetLatestVideoPreviewsRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        var call = CreateCall(__Method_GetLatestVideoPreviews, new CallOptions(headers, deadline, cancellationToken));
        return Calls.AsyncUnaryCall(call, request);
      }
      public AsyncUnaryCall<global::KillrVideo.VideoCatalog.GetLatestVideoPreviewsResponse> GetLatestVideoPreviewsAsync(global::KillrVideo.VideoCatalog.GetLatestVideoPreviewsRequest request, CallOptions options)
      {
        var call = CreateCall(__Method_GetLatestVideoPreviews, options);
        return Calls.AsyncUnaryCall(call, request);
      }
      public global::KillrVideo.VideoCatalog.GetUserVideoPreviewsResponse GetUserVideoPreviews(global::KillrVideo.VideoCatalog.GetUserVideoPreviewsRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        var call = CreateCall(__Method_GetUserVideoPreviews, new CallOptions(headers, deadline, cancellationToken));
        return Calls.BlockingUnaryCall(call, request);
      }
      public global::KillrVideo.VideoCatalog.GetUserVideoPreviewsResponse GetUserVideoPreviews(global::KillrVideo.VideoCatalog.GetUserVideoPreviewsRequest request, CallOptions options)
      {
        var call = CreateCall(__Method_GetUserVideoPreviews, options);
        return Calls.BlockingUnaryCall(call, request);
      }
      public AsyncUnaryCall<global::KillrVideo.VideoCatalog.GetUserVideoPreviewsResponse> GetUserVideoPreviewsAsync(global::KillrVideo.VideoCatalog.GetUserVideoPreviewsRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        var call = CreateCall(__Method_GetUserVideoPreviews, new CallOptions(headers, deadline, cancellationToken));
        return Calls.AsyncUnaryCall(call, request);
      }
      public AsyncUnaryCall<global::KillrVideo.VideoCatalog.GetUserVideoPreviewsResponse> GetUserVideoPreviewsAsync(global::KillrVideo.VideoCatalog.GetUserVideoPreviewsRequest request, CallOptions options)
      {
        var call = CreateCall(__Method_GetUserVideoPreviews, options);
        return Calls.AsyncUnaryCall(call, request);
      }
    }

    // creates service definition that can be registered with a server
    public static ServerServiceDefinition BindService(IVideoCatalogService serviceImpl)
    {
      return ServerServiceDefinition.CreateBuilder(__ServiceName)
          .AddMethod(__Method_SubmitUploadedVideo, serviceImpl.SubmitUploadedVideo)
          .AddMethod(__Method_SubmitYouTubeVideo, serviceImpl.SubmitYouTubeVideo)
          .AddMethod(__Method_GetVideo, serviceImpl.GetVideo)
          .AddMethod(__Method_GetVideoPreviews, serviceImpl.GetVideoPreviews)
          .AddMethod(__Method_GetLatestVideoPreviews, serviceImpl.GetLatestVideoPreviews)
          .AddMethod(__Method_GetUserVideoPreviews, serviceImpl.GetUserVideoPreviews).Build();
    }

    // creates a new client
    public static VideoCatalogServiceClient NewClient(Channel channel)
    {
      return new VideoCatalogServiceClient(channel);
    }

  }
}
#endregion
