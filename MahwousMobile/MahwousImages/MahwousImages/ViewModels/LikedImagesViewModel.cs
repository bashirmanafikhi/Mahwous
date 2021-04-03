using MahwousMobile.Base.Helpers;
using MahwousImages.Helpers;
using MahwousWeb.Shared.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace MahwousImages.ViewModels
{

    class LikedImagesViewModel : BaseViewModel
    {
        public ObservableCollection<ImageStatus> Images { get; set; }

        public Command LoadImagesCommand { get; set; }

        public LikedImagesViewModel()
        {
            Images = new ObservableCollection<ImageStatus>();
            LoadImagesCommand = new Command(() => ExecuteLoadImagesCommand());
        }

        private void ExecuteLoadImagesCommand()
        {
            IsBusy = true;
            Images.Clear();
            try
            {
                MahwousSqliteDB<ImageStatus> database = new MahwousSqliteDB<ImageStatus>();

                var images = database.ReadAll();
                foreach (var image in images)
                {
                    Images.Add(image);
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
    }
}
