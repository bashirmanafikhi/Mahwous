using Mahwous.Core.Entities;
using Mahwous.Core.Pagination;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MahwousMobile.Base.ViewModels
{

    public class ChatRoomsViewModel : BaseViewModel
    {
        PaginationDetails paginationDetails = new PaginationDetails();
        private int totalAmountPages;


        bool isLoadingMore = false;
        public bool IsLoadingMore
        {
            get { return isLoadingMore; }
            set { SetProperty(ref isLoadingMore, value); }
        }

        private int itemTreshold = 3;
        public int ItemTreshold
        {
            get { return itemTreshold; }
            set { SetProperty(ref itemTreshold, value); }
        }

        public event EventHandler ChatRoomsFinished;

        public ObservableCollection<ChatRoom> ChatRooms { get; set; }
        public Command LoadChatRoomsCommand { get; set; }
        public Command LoadMoreChatRoomsCommand { get; set; }

        public ChatRoomsViewModel()
        {

            ChatRooms = new ObservableCollection<ChatRoom>();

            LoadChatRoomsCommand = new Command(async () => await ExecuteLoadChatRoomsCommand());
            LoadMoreChatRoomsCommand = new Command(async () => await ExecuteLoadMoreChatRoomsCommand());
        }


        async Task ExecuteLoadMoreChatRoomsCommand()
        {
            if (!IsLoadingMore)
            {
                Debug.WriteLine("Bashir: Loading More");
                IsLoadingMore = true;

                try
                {
                    if (paginationDetails.PageIndex < totalAmountPages)
                    {
                        paginationDetails.PageIndex++;
                        var paginatedResponse = await Repositories.ChatRoomRepository.Search(paginationDetails);
                        foreach (var chatRoom in paginatedResponse.Items)
                            ChatRooms.Add(chatRoom);
                    }
                    else
                    {
                        ChatRoomsFinished?.Invoke(this, EventArgs.Empty);
                        ItemTreshold = -1;
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    IsLoadingMore = false;
                }
            }
        }

        async Task ExecuteLoadChatRoomsCommand()
        {
            //if (IsBusy && ChatRooms.Count == 0)
            //{
            //    return;
            //}

            IsBusy = true;

            try
            {
                ChatRooms.Clear();
                paginationDetails.PageIndex = 1;

                var paginatedResponse = await Repositories.ChatRoomRepository.Search(paginationDetails);
                totalAmountPages = paginatedResponse.TotalPages;
                var chatRooms = paginatedResponse.Items;
                foreach (var chatRoom in chatRooms)
                {
                    ChatRooms.Add(chatRoom);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
