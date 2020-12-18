using MahwousWeb.Shared.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using MahwousVideos.Helpers;

namespace MahwousVideos.ViewModels
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
                await initRandomVideo();
                Informations = await Repositories.VideosRepository.GetInformations();
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


        bool isGettingRandomVideo = false;
        public bool IsGettingRandomVideo
        {
            get { return isGettingRandomVideo; }
            set { SetProperty(ref isGettingRandomVideo, value); }
        }
        private async Task initRandomVideo()
        {
            IsGettingRandomVideo = true;

            try
            {
                //Video = new VideoStatus();
                Video = await Repositories.VideosRepository.GetRandom();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsGettingRandomVideo = false;
            }
        }

        private VideoStatus quote;
        public VideoStatus Video
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
