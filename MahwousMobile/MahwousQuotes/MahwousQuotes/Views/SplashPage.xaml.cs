using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousQuotes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
    {
        readonly Image splashImage;

        public SplashPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "my_logo.png",
                WidthRequest = 100,
                HeightRequest = 100
            };
            AbsoluteLayout.SetLayoutFlags(splashImage,
               AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage,
             new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);

            //this.BackgroundColor = Color.FromHex("#FF2d4059");
            this.BackgroundColor = (Color)Application.Current.Resources["NavigationPrimary"];


            this.Content = sub;
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //await splashImage.ScaleTo(1, 2000); //Time-consuming processes such as initialization
            await splashImage.ScaleTo(3, 2000, Easing.Linear);
            //await splashImage.ScaleTo(25, 1000, Easing.Linear);

            Application.Current.MainPage = new AppShell();    //After loading  MainPage it gets Navigated to our new Page
        }
    }
}