using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mahwous.Chat.Hubs
{
    public class ChatHub : Hub
    {
        public ChatHub()
        {

        }


        // Methods
        public async Task SendMessage(int roomId, string userName, string message)
        {
            await Clients.Others.SendAsync($"Room{roomId}", userName, message);
        }


        // connections
        public override Task OnConnectedAsync()
        {
            connectedIds.Add(Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            connectedIds.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
        private static HashSet<string> connectedIds = new HashSet<string>();
    }
}
