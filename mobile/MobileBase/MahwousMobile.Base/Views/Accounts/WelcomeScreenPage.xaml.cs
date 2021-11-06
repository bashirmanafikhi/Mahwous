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
            NavigationPage.SetHasNavigationBar(this, false);
            AnimateCarousel();
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
            try
            {
                await Navigation.PushAsync(new RegisterPage());
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                DependencyService.Get<IMessage>().LongAlert(ex.Message);
            }
        }
        private async void Login_Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new LoginPage());
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                DependencyService.Get<IMessage>().LongAlert(ex.Message);
            }
        }
        private void GoToTheMainShell(object sender, EventArgs e)
        {
            try
            {
                Application.Current.MainPage = Settings.MainShellWindow;
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                DependencyService.Get<IMessage>().LongAlert(ex.Message);
            }
        }


    }
}