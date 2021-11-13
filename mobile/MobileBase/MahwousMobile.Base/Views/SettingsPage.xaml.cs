using MahwousMobile.Base.Styles.Themes;
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
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            GetCurrentSettings();
        }

        private void GetCurrentSettings()
        {
            if (Application.Current.RequestedTheme == OSAppTheme.Dark)
                darkSwitch.IsToggled = true;
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == true)
                Application.Current.Resources = new DarkTheme();
            else
                Application.Current.Resources = new WhiteTheme();
        }
    }
}