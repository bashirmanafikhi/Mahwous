using MahwousMobile.Base.Helpers;
using MahwousMobile.Base.ViewModels;
using Microsoft.AppCenter.Crashes;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousMobile.Base.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
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

            /*
             var vm = new AccountsViewModel();
            this.BindingContext = vm;
            InitializeComponent();

            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                vm.LoginCommand.Execute(null);
            };
             * */
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var loggedin = Settings.Token != null;
            if (loggedin)
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }

        private async void GoToRegisterPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");

        }

        private async void OpenPrivacyPolicyPage(object sender, EventArgs e)
        {
            PrivacyPolicyPage page = new PrivacyPolicyPage();
            await Navigation.PushModalAsync(page);
        }

        private async void OpenTermsAndConditionsPage(object sender, EventArgs e)
        {
            TermsAndConditionsPage page = new TermsAndConditionsPage();
            await Navigation.PushModalAsync(page);
        }
    }
}