using MahwousQuotes.Helpers;
using MahwousQuotes.Styles.Themes;
using MahwousQuotes.ViewModels;
using MahwousWeb.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousQuotes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        HomeViewModel viewModel;
        public HomePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new HomeViewModel();


            if (Preferences.ContainsKey("dark_mode"))
            {
                homePageImage.Source = ImageSource.FromFile("TransparentWhite.png");
                darkSwitch.IsToggled = true;
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

                Preferences.Remove("dark_mode");
            }
        }
    }
}