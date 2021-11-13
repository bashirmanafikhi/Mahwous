using MahwousMobile.Base.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MahwousMobile.Base.Views
{
    [DesignTimeVisible(false)]
    public partial class ChatRoomsPage : ContentPage
    {
        ChatRoomsViewModel viewModel;

        public ChatRoomsPage()
        {
            InitializeComponent();

            this.viewModel = (BindingContext as ChatRoomsViewModel);
        }

        protected override void OnAppearing()
        {
            if (viewModel.ChatRooms.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}