using MahwousWeb.Shared.Models;
using System;
using System.Diagnostics;
using System.Linq;
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


        private FilteredInformations informations;
        public FilteredInformations Informations
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
                Informations = await Repositories.QuoteRepository.GetInformations();
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
                Quote = await Repositories.QuoteRepository.GetRandomQuote();
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
