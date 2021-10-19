using Mahwous.Service.Repositories;
using Mahwous.Service.ViewModels.ImageStatuses;
using MahwousMobile.Base.Helpers;
using Microsoft.AppCenter.Crashes;
using System;
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
                CreateImageStatusCommand command = new CreateImageStatusCommand
                {
                    Image = stream
                };
                var id = await Repositories.ImageStatusRepository.Create(command);

            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                DependencyService.Get<IMessage>().LongAlert(ex.Message);
            }

        }
    }
}