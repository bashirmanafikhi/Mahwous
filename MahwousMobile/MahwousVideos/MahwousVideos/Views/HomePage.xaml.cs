using MahwousVideos.Styles.Themes;
using MahwousVideos.ViewModels;
using MediaManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MahwousVideos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            BindingContext = new HomeViewModel();

            //CrossMediaManager.Current.StateChanged += MediaPlayer_StateChanged;

            if (Preferences.ContainsKey("dark_mode"))
            {
                homePageImage.Source = ImageSource.FromFile("TransparentWhite.png");
                darkSwitch.IsToggled = true;
            }
        }

        //private void MediaPlayer_StateChanged(object sender, MediaManager.Playback.StateChangedEventArgs e)
        //{
        //    if (e.State == MediaManager.Player.MediaPlayerState.Playing ||
        //        e.State == MediaManager.Player.MediaPlayerState.Paused ||
        //        e.State == MediaManager.Player.MediaPlayerState.Buffering)
        //    {
        //        mediaPlayer.IsVisible = true;
        //    }
        //    else
        //    {
        //        mediaPlayer.IsVisible = false;
        //    }
        //}

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == true)
            {
                Application.Current.Resources = new DarkTheme();
                homePageImage.Source = ImageSource.FromFile("TransparentWhite.png");

                Preferences.Set("dark_mode", true);
            }
            else
            {
                Application.Current.Resources = new WhiteTheme();
                homePageImage.Source = ImageSource.FromFile("TransparentBlack.png");

                Preferences.Remove("dark_mode");
            }
        }
    }
}