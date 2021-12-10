using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Mahwous.Service.Chat
{
    public class ChatService : IChatService
    {
        private HubConnection hubConnection;
        private readonly string url;

        //public static readonly string URL = @"https://www.mahwous.com/";
        //public static readonly string IP = @"http://192.168.0.113:60485/";
        //public static readonly string Localhost = @"http://localhost:60485/";

        public ChatService(string url, string token)
        {
            this.url = url;

            Init(token);
        }

        private void Init(string token = null)
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl($"{url}ChatHub/", option =>
                {
                    if(!string.IsNullOrEmpty(token))
                        option.AccessTokenProvider = () => Task.FromResult(token);
                })
                .Build();

            hubConnection.Closed += async (error) =>
            {
                await Task.Delay(4000);
                await Connect();
            };
        }


        public async Task SetToken(string token)
        {
            await hubConnection.DisposeAsync();
            Init(token);
            await Connect();
        }

        public async Task Connect()
        {
            try
            {
                if(State == HubConnectionState.Disconnected)
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

        public async Task SendMessage(int roomId, string message)
        {
            await hubConnection.InvokeAsync("SendMessage", roomId, message);
        }

        public void ReceiveMessage(Action<string, string> GetMessageAndUser)
        {
            hubConnection.On("Room", GetMessageAndUser);
        }

        public async Task JoinRoom(int roomId)
        {
            await hubConnection.InvokeAsync("JoinRoom", roomId);
        }

        public async Task LeaveRoom(int roomId)
        {
            await hubConnection.InvokeAsync("LeaveRoom", roomId);
        }
    }
}
