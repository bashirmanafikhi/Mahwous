using Mahwous.Application.Features.Messages;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mahwous.Chat.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IMediator mediator;
        public ChatHub(IMediator mediator)
        {
            this.mediator = mediator;
        }


        // Methods
        public async Task SendMessage(int roomId, string message)
        {
            string userId = Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string userName = Context.User.Identity.Name;


            await Clients.OthersInGroup(roomId.ToString()).SendAsync("Room", userName, message);

            var command = new CreateMessageCommand();
            command.Content = message;
            command.RoomId = roomId;
            command.UserId = userId;
            await mediator.Send(command);
        }

        public Task JoinRoom(int roomId)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
        }

        public Task LeaveRoom(int roomId)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId.ToString());
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
        private static HashSet<string> connectedIds = new();
    }
}
