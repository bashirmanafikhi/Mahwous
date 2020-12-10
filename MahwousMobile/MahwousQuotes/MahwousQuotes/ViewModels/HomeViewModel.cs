using MahwousWeb.Shared.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MahwousQuotes.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {

            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.mahwous.com"));
            GetInformationsCommand = new Command(ExecuteGetInformationsCommand);

            initializeTimer();
        }

        void initializeTimer()
        {
            ExecuteGetInformationsCommand();
            Device.StartTimer(TimeSpan.FromSeconds(60), () =>
            {
                ExecuteGetInformationsCommand();
                return true; // return true to repeat counting, false to stop timer
            });
        }


        private Informations informations;
        public Informations Informations
        {
            get { return informations; }
            set { SetProperty(ref informations, value); }
        }

        private async void ExecuteGetInformationsCommand()
        {
            IsBusy = true;

            try
            {
                await initRandomQuote();
                Informations = await Repositories.QuotesRepository.GetInformations();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public ICommand GetInformationsCommand { get; }
        public ICommand OpenWebCommand { get; }


        bool isGettingRandomQuote = false;
        public bool IsGettingRandomQuote
        {
            get { return isGettingRandomQuote; }
            set { SetProperty(ref isGettingRandomQuote, value); }
        }
        private async Task initRandomQuote()
        {
            IsGettingRandomQuote = true;

            try
            {
                //Quote = new QuoteStatus();
                Quote = await Repositories.QuotesRepository.GetRandom();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsGettingRandomQuote = false;
            }
        }

        private QuoteStatus quote;
        public QuoteStatus Quote
        {
            get
            {
                return quote;
            }
            set
            {
                SetProperty(ref quote, value);
            }
        }
    }
}
