using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Mahwous.Chat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string roomName, string userName, string message)
        {
            await Clients.Others.SendAsync($"Room{roomName}", userName, message);
        }
    }
}
