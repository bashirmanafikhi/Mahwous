using MahwousWeb.Models.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using MahwousMobile.Base.Helpers;
using MahwousMobile.Base.Models;

namespace MahwousMobile.Base.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel(StatusType? statusType = null)
        {
            StatusType = statusType;
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.mahwous.com"));
            GetInformationsCommand = new Command(() => ExecuteGetInformationsCommand());

            initializeTimer();
        }

        void initializeTimer()
        {
            ExecuteGetInformationsCommand();
            Device.StartTimer(TimeSpan.FromSeconds(90), () =>
            {
                ExecuteGetInformationsCommand();
                return true; // return true to repeat counting, false to stop timer
            });
        }

        public StatusType? StatusType { get; set; }

        private Informations informations;
        public Informations Informations
        {
            get { return informations; }
            set { 
                SetProperty(ref informations, value);
            }
        }

        private async void ExecuteGetInformationsCommand()
        {
            //if (!StatusType.HasValue) return;

            IsBusy = true;

            try
            {
                //await initRandomImage();
                switch (StatusType)
                {
                    case Models.StatusType.Image:
                        Informations = await Repositories.ImagesRepository.GetInformations();
                        break;
                    case Models.StatusType.Video:
                        Informations = await Repositories.VideosRepository.GetInformations();
                        break;
                    case Models.StatusType.Quote:
                        Informations = await Repositories.QuotesRepository.GetInformations();
                        break;
                    default:
                        Informations = await Repositories.StatusesRepository.GetInformations();
                        break;
                }

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


        //bool isGettingRandomImage = false;
        //public bool IsGettingRandomImage
        //{
        //    get { return isGettingRandomImage; }
        //    set { SetProperty(ref isGettingRandomImage, value); }
        //}
        //private async Task initRandomImage()
        //{
        //    IsGettingRandomImage = true;

        //    try
        //    {
        //        //Image = new ImageStatus();
        //        Image = await Repositories.ImagesRepository.GetRandom();
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //    }
        //    finally
        //    {
        //        IsGettingRandomImage = false;
        //    }
        //}

        //private ImageStatus image;
        //public ImageStatus Image
        //{
        //    get
        //    {
        //        return image;
        //    }
        //    set
        //    {
        //        SetProperty(ref image, value);
        //    }
        //}
    }
}
