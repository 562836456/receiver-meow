﻿using Newbe.Mahua.MahuaEvents;
using Newbe.Mahua.Receiver.Meow.MahuaApis;
using System;

namespace Newbe.Mahua.Receiver.Meow.MahuaEvents
{
    /// <summary>
    /// 入群邀请接收事件
    /// </summary>
    public class GroupJoiningInvitationReceivedMahuaEvent
        : IGroupJoiningInvitationReceivedMahuaEvent
    {
        private readonly IMahuaApi _mahuaApi;

        public GroupJoiningInvitationReceivedMahuaEvent(
            IMahuaApi mahuaApi)
        {
            _mahuaApi = mahuaApi;
        }

        public void ProcessJoinGroupRequest(GroupJoiningRequestReceivedContext context)
        {
            if (context.FromQq == "290927815" || context.FromQq == "961726194")
                _mahuaApi.AcceptGroupJoiningInvitation(context.GroupJoiningRequestId, context.ToGroup, context.FromQq);
            else
                _mahuaApi.RejectGroupJoiningInvitation(context.GroupJoiningRequestId, context.ToGroup, context.FromQq, "禁止加群，如有需要请联系开发者");
        }
    }
}
