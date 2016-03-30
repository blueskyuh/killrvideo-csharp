﻿using System.ComponentModel.Composition;
using Cassandra;
using DryIocAttributes;
using Grpc.Core;
using KillrVideo.Cassandra;
using KillrVideo.MessageBus;

namespace KillrVideo.Comments
{
    /// <summary>
    /// Static factory for creating a ServerServiceDefinition for the Comments Service for use with a Grpc Server.
    /// </summary>
    [Export, AsFactory]
    public static class CommentsServiceFactory
    {
        [Export]
        public static ServerServiceDefinition Create(ISession cassandra, PreparedStatementCache statementCache, IBus bus)
        {
            var commentsService = new CommentsServiceImpl(cassandra, statementCache, bus);
            return CommentsService.BindService(commentsService);
        }
    }
}
