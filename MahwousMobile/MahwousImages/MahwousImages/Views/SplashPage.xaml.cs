using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousImages.Views
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
                Source = "TransparentWhite.png",
                WidthRequest = 150,
                HeightRequest = 150
            };
            AbsoluteLayout.SetLayoutFlags(splashImage,
               AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage,
             new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);

            //this.BackgroundColor = Color.FromHex("#FF2d4059");
            this.BackgroundColor = (Color)Application.Current.Resources["colBlack"];


            this.Content = sub;
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //await splashImage.ScaleTo(1, 2000);
            await splashImage.ScaleTo(1, 2000, Easing.Linear); //Time-consuming processes such as initialization
            await splashImage.ScaleTo(0.5, 100, Easing.Linear);
            await splashImage.ScaleTo(2, 500, Easing.Linear);

            Application.Current.MainPage = new AppShell();    //After loading  MainPage it gets Navigated to our new Page
        }
    }
}