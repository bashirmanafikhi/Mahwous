using MahwousMobile.Base.Helpers;
using MahwousMobile.Base.ViewModels;
using Microsoft.AppCenter.Crashes;
using System;

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
                vm.LoggedSuccessfully += async () =>
                {
                    await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                };
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                DependencyService.Get<IMessage>().LongAlert(ex.Message);
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var loggedin = Settings.Token != null;
            if (loggedin)
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }

        private async void GoToLoginPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}