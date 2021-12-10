using Mahwous.Core.Entities;
using MahwousMobile.Base.Helpers;
using MahwousMobile.Base.ViewModels;
using MahwousMobile.Base.Views;
using MarcTron.Plugin;
using System;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousMobile.Base.Templates.DataTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatRoomTemplate : ContentView
    {
        public ChatRoomTemplate()
        {
            InitializeComponent();
        }

        private async void Item_Tapped(object sender, EventArgs e)
        {
            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                CrossMTAdmob.Current.ShowInterstitial();


            var layout = (BindableObject)sender;
            var chatRoom = (ChatRoom)layout.BindingContext;

            ChatRoomViewModel viewModel = new ChatRoomViewModel(chatRoom);
            ChatRoomPage page = new ChatRoomPage(viewModel);

            var previousPage = Navigation.NavigationStack.LastOrDefault();
            await Navigation.PushAsync(page);
            if (previousPage != null && previousPage is ChatRoomPage)
            {
                Navigation.RemovePage(previousPage);
            }
        }
    }
}