using MahwousMobile.Base.Helpers;
using MahwousMobile.Base.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousMobile.Base.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatRoomPage : ContentPage
    {
        private readonly ChatRoomViewModel viewModel;
        public ChatRoomPage(ChatRoomViewModel viewModel)
        {
            var loggedin = Settings.Token != null;
            if (!loggedin)
                Shell.Current.GoToAsync($"//{nameof(WelcomeScreenPage)}");


            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        protected override async void OnAppearing()
        {
            var loggedin = Settings.Token != null;
            if (!loggedin)
                await Shell.Current.GoToAsync($"//{nameof(WelcomeScreenPage)}");

            viewModel.JoinRoom();
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            viewModel.LeaveRoom();
            base.OnDisappearing();
        }
    }
}