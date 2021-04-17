using MahwousMobile.Base.Models;
using MahwousMobile.Base.Styles.Themes;
using MahwousMobile.Base.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MahwousMobile.Base.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            //CrossMediaManager.Current.StateChanged += MediaPlayer_StateChanged;

            if (Preferences.Get("dark_mode", true))
            {
                homePageImage.Source = ImageSource.FromFile("TransparentWhite.png");
                darkSwitch.IsToggled = true;
            }
        }

        public StatusType? StatusType
        {
            set
            {
                BindingContext = new HomeViewModel(value);
            }
        }

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

                Preferences.Set("dark_mode", false);
            }
        }
    }
}