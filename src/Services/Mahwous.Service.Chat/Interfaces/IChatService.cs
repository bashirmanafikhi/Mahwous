using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahwous.Service.Chat
{
    public interface IChatService
    {
        HubConnectionState State { get; }

        Task Connect();
        Task Disconnect();
        void ReceiveMessage(Action<string, string> GetMessageAndUser);
        Task SendMessage(int roomId, string message);
        Task SetToken(string token);
        Task JoinRoom(int roomId);
        Task LeaveRoom(int roomId);
    }
}
