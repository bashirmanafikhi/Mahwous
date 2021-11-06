using MahwousMobile.Base.Models;
using MahwousMobile.Base.Styles.Themes;
using MahwousMobile.Base.ViewModels;
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

            if (Application.Current.RequestedTheme == OSAppTheme.Dark)
                darkSwitch.IsToggled = true;
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
                Application.Current.Resources = new DarkTheme();
            else
                Application.Current.Resources = new WhiteTheme();
        }
    }
}