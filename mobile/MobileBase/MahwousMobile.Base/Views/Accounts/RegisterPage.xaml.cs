using MahwousMobile.Base.Helpers;
using MahwousMobile.Base.ViewModels;
using Microsoft.AppCenter.Crashes;
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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            try
            {
                InitializeComponent();
                var vm = (AccountsViewModel)BindingContext;
                vm.LoggedSuccessfully += () =>
                {
                    Application.Current.MainPage = Settings.MainShellWindow;
                };
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                DependencyService.Get<IMessage>().LongAlert(ex.Message);
            }
        }

        private async void GoToLoginPage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}