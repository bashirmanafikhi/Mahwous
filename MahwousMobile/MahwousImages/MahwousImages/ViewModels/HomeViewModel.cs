using MahwousWeb.Models.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using MahwousImages.Helpers;

namespace MahwousImages.ViewModels
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
            set { 
                SetProperty(ref informations, value);
                //MySharedData.CategoriesStatusCounts = informations.CategoriesStatusCounts;
            }
        }

        private async void ExecuteGetInformationsCommand()
        {
            IsBusy = true;

            try
            {
                await initRandomImage();
                Informations = await Repositories.ImagesRepository.GetInformations();
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


        bool isGettingRandomImage = false;
        public bool IsGettingRandomImage
        {
            get { return isGettingRandomImage; }
            set { SetProperty(ref isGettingRandomImage, value); }
        }
        private async Task initRandomImage()
        {
            IsGettingRandomImage = true;

            try
            {
                //Image = new ImageStatus();
                Image = await Repositories.ImagesRepository.GetRandom();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsGettingRandomImage = false;
            }
        }

        private ImageStatus quote;
        public ImageStatus Image
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
