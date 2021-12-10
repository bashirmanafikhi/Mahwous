using AutoMapper;
using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;
using Mahwous.Service.Chat;
using Mahwous.Service.ViewModels.Messages;
using MahwousMobile.Base.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MahwousMobile.Base.ViewModels
{
    public class ChatRoomViewModel : BaseViewModel
    {
        private readonly IChatService chatService = DependencyService.Get<IChatService>();
        public ObservableCollection<GetMessageDetailsResponse> MessagesList { get; set; }
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
        public PaginationDetails Pagination { get; private set; } = new PaginationDetails(1, 50);

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
            MessagesList = new ObservableCollection<GetMessageDetailsResponse>();
            chatService.ReceiveMessage(GetMessage);
            RetriveOldMessages();
        }

        public void JoinRoom() => chatService.JoinRoom(ChatRoom.Id);

        public void LeaveRoom() => chatService.LeaveRoom(ChatRoom.Id);

        private async void RetriveOldMessages()
        {
            MessageFilter filter = new MessageFilter
            {
                RoomId = ChatRoom.Id
            };

            var response = await Repositories.MessagesRepository.Search(Pagination, filter);
            var messages = response.Items;
            foreach (var message in messages)
                MessagesList.Add(message);
        }

        async void SendMessage()
        {
            await chatService.SendMessage(ChatRoom.Id, Message);
            AddMessage(UserName, Message, true);
        }

        private void GetMessage(string userName, string message)
        {
            AddMessage(userName, message, false);
        }

        private void AddMessage(string userName, string message, bool isOwner)
        {
            var messageModel = new GetMessageDetailsResponse { Content = message, OwnerName = userName, IsOwner = isOwner };
            MessagesList.Add(messageModel);

            Message = string.Empty;
        }

    }
}
