﻿using Application.Visitors.VisitorOnline;
using Microsoft.AspNetCore.SignalR;

namespace WebSite.EndPoint.Hubs
{
    public class OnlineVisitorHub:Hub
    {
        private readonly IVisitorOnlineService visitorOnlineService;
        public OnlineVisitorHub(IVisitorOnlineService visitorOnlineService)
        {
            this.visitorOnlineService = visitorOnlineService;
        }
        public override Task OnConnectedAsync()
         {
            string VisitorId = Context.GetHttpContext().Request.Cookies["VisitorId"];

            visitorOnlineService.ConnectUser(VisitorId);
            var count = visitorOnlineService.GetCount();
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            string VisitorId = Context.GetHttpContext().Request.Cookies["VisitorId"];

            visitorOnlineService.DisConnectUser(VisitorId);
            var count = visitorOnlineService.GetCount();
            return base.OnDisconnectedAsync(exception);
        }
    }
}
