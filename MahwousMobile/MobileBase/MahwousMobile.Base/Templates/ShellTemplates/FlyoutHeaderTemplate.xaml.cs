using MahwousMobile.Base.Helpers;
using MahwousMobile.Base.Views;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousMobile.Base.Templates.ShellTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutHeaderTemplate : ContentView
    {
        public FlyoutHeaderTemplate()
        {
            InitializeComponent();
        }

        async void OnProfileImageTapped(object sender, EventArgs e)
        {
            try
            {
                LoginPage login = new LoginPage();
                await Navigation.PushAsync(login);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                DependencyService.Get<IMessage>().ShortAlert(ex.Message);
            }
        }

        private void GoToProfilePage(object sender, EventArgs e)
        {

        }
    }
}