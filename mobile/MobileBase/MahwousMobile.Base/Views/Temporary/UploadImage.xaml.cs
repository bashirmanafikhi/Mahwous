using MahwousMobile.Base.Helpers;
using Mahwous.Core.Models;
using MahwousWeb.Service.Repositories;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MahwousMobile.Base.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UploadImage : ContentPage
    {
        public UploadImage()
        {
            InitializeComponent();
        }
        public MahwousRepositories Repositories => DependencyService.Get<MahwousRepositories>();

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var file = await MediaPicker.PickPhotoAsync();

                if (file == null)
                    return;

                var stream = await file.OpenReadAsync();
                var id = await Repositories.ImagesRepository.Add(new ImageStatus(), stream);

            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                DependencyService.Get<IMessage>().LongAlert(ex.Message);
            }

        }
    }
}