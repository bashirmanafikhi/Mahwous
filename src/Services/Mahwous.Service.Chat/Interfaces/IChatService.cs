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
        void ReceiveMessage(int roomId, Action<string, string> GetMessageAndUser);
        Task SendMessage(int roomId, string userName, string message);
    }
}
