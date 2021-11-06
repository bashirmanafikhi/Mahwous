using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Mahwous.Service.Chat
{
    public class ChatService : IChatService
    {
        private readonly HubConnection hubConnection;
        //public static readonly string URL = @"https://www.mahwous.com/";
        //public static readonly string IP = @"http://192.168.0.113:60485/";
        //public static readonly string Localhost = @"http://localhost:60485/";

        public ChatService(string url)
        {
            hubConnection = new HubConnectionBuilder().WithUrl($"{url}ChatHub/").Build();

            hubConnection.Closed += async (error) =>
            {
                await Task.Delay(4000);
                await Connect();
            };
        }

        public async Task Connect()
        {
            try
            {
                await hubConnection.StartAsync();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                //throw ex;
            }
        }

        public HubConnectionState State => hubConnection.State;

        public async Task Disconnect()
        {
            await hubConnection.StopAsync();
        }

        public async Task SendMessage(int roomId, string userName, string message)
        {
            await hubConnection.InvokeAsync("SendMessage", roomId, userName, message);
        }

        public void ReceiveMessage(int roomId, Action<string, string> GetMessageAndUser)
        {
            hubConnection.On($"Room{roomId}", GetMessageAndUser);
        }

    }
}
