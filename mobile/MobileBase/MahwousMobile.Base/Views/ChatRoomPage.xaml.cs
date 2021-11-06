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
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }
    }
}