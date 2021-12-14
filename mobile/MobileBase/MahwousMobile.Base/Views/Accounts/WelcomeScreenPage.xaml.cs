using MahwousMobile.Base.Helpers;
using Microsoft.AppCenter.Crashes;
using System;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousMobile.Base.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomeScreenPage : ContentPage
    {
        public WelcomeScreenPage()
        {
            InitializeComponent();
            AnimateCarousel();
        }
        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var loggedin = Settings.Token != null;
            if (loggedin)
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }

        Timer timer;
        private void AnimateCarousel()
        {
            timer = new Timer(5000)
            {
                AutoReset = true,
                Enabled = true
            };
            timer.Elapsed += (s, e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (cvOnBoardList.Position == 2)
                    {
                        cvOnBoardList.Position = 0;
                        return;
                    }
                    cvOnBoardList.Position += 1;
                });
            };
        }

        private async void Register_Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
        }
        private async void Login_Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
        private async void GoToTheMainShell(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
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