using MahwousMobile.Base.Helpers;
using MahwousMobile.Base.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace MahwousMobile.Base.ViewModels
{

    class LikedImagesViewModel : BaseViewModel
    {
        public ObservableCollection<ImageViewModel> Images { get; set; }

        public Command LoadImagesCommand { get; set; }

        public LikedImagesViewModel()
        {
            Images = new ObservableCollection<ImageViewModel>();
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
                    Images.Add(new ImageViewModel(image));
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
