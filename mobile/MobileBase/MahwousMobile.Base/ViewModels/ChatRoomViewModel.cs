using AutoMapper;
using Mahwous.Core.Entities;
using Mahwous.Service.Chat;
using MahwousMobile.Base.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MahwousMobile.Base.ViewModels
{
    public class ChatRoomViewModel : BaseViewModel
    {
        private readonly IChatService chatService = DependencyService.Get<IChatService>();
        public ObservableCollection<MessageModel> MessagesList { get; set; }
        public ICommand SendMessageCommand { get; private set; }

        readonly ChatRoom chatRoom;
        public ChatRoom ChatRoom => chatRoom;


        private string message;
        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }

        public string UserName { get; set; }

        public ChatRoomViewModel()
        {
            chatRoom = new ChatRoom();
        }

        public ChatRoomViewModel(ChatRoom chatRoom)
        {
            this.chatRoom = chatRoom;
            try
            {
                chatService.Connect();
            }
            catch (Exception ex)
            {
                MessageService.LongAlert(ex.Message);
            }

            UserName = (new Random()).Next().ToString();
            SendMessageCommand = new Command(SendMessage);
            MessagesList = new ObservableCollection<MessageModel>();
            chatService.ReceiveMessage(chatRoom.Id, GetMessage);
        }

        async void SendMessage()
        {
            await chatService.SendMessage(ChatRoom.Id, UserName, Message);
            AddMessage(UserName, Message, true);
        }

        private void GetMessage(string userName, string message)
        {
            AddMessage(userName, message, false);
        }

        private void AddMessage(string userName, string message, bool isOwner)
        {
            var messageModel = new MessageModel { IsOwnerMessage = isOwner, Message = message, UserName = userName };
            MessagesList.Add(messageModel);

            Message = string.Empty;
        }

    }
}
