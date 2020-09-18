using MahwousVideos.Styles.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            if (Application.Current.Properties.ContainsKey("dark_mode"))
            {
                homePageImage.Source = ImageSource.FromFile("TransparentWhite.png");
                darkSwitch.IsToggled = true;
            }
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            // Todo:  merge this with app.cs function
            
            if (e.Value == true)
            {
                //Application.Current.Resources.Clear();
                Application.Current.Resources = new DarkTheme();
                homePageImage.Source = ImageSource.FromFile("TransparentWhite.png");

                Application.Current.Properties["dark_mode"] = true;
            }
            else
            {
                //Application.Current.Resources.Clear();
                Application.Current.Resources = new WhiteTheme();
                homePageImage.Source = ImageSource.FromFile("TransparentBlack.png");

                Application.Current.Properties["dark_mode"] = false;
            }
        }
    }
}