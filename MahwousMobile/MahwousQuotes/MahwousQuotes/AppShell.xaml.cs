using MahwousQuote.ViewModels;
using MahwousQuotes.Helpers;
using MahwousQuotes.Models;
using MahwousQuotes.Views;
using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousQuotes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private void MenuItem_Exit_Clicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private async void MenuItem_Rate_Clicked(object sender, EventArgs e)
        {
            string Uri = "https://play.google.com/store/apps/details?id=com.mahwous.mahwousquotes";
            await Browser.OpenAsync(Uri);
        }

        private async void MenuItem_ShareApp_Clicked(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Uri = "https://play.google.com/store/apps/details?id=com.mahwous.mahwousquotes",
                Title = "مشاركة تطبيق مهووس"
            });
        }

        private async void MenuItem_RandomQuote_Clicked(object sender, EventArgs e)
        {
            try
            {
                var repository = DependencyService.Get<Repositories>().QuoteRepository;
                var quote = await repository.GetRandomQuote();
                var viewModel = new QuoteViewModel(quote);

                Shell.Current.FlyoutIsPresented = false;

                var previousPage = Navigation.NavigationStack.LastOrDefault();
                await Navigation.PushAsync(new QuoteDetailsPage(viewModel));
                if (previousPage != null && previousPage is QuoteDetailsPage)
                    Navigation.RemovePage(previousPage);
            }
            catch (Exception)
            {

            }
            

        }

        private async void MenuItem_LikedQuotes_Clicked(object sender, EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = false;

            await Navigation.PushModalAsync(new LikedQuotesPage());
        }


        private bool maybe_exit = false;
        //-------------------------------------------------------------------
        protected override bool OnBackButtonPressed()
        //-------------------------------------------------------------------
        {
            if (Navigation.NavigationStack.Count > 1 || Navigation.ModalStack.Count > 1)
            {
                return base.OnBackButtonPressed();
            }
            //some more custom checks here
            //..

            if (maybe_exit) return false; //QUIT

            DependencyService.Get<IMessage>().ShortAlert("إضغط مرة أخرة للخروج من البرنامج!");
            maybe_exit = true;

            Device.StartTimer(TimeSpan.FromSeconds(2), () =>
            {
                maybe_exit = false; //reset those 2 seconds
                                    
                return false;// false - Don't repeat the timer 
            });
            return true; //true - don't process BACK by system
        }
    }
}