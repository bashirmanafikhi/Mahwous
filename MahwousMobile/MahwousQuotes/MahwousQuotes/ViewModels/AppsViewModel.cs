using MahwousWeb.Shared.Pagination;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace MahwousQuotes.ViewModels
{

    public class AppsViewModel : BaseViewModel
    {
        readonly PaginationDetails paginationDTO = new PaginationDetails() { RecordsPerPage = 200 };


        bool isLoadingMore = false;
        public bool IsLoadingMore
        {
            get { return isLoadingMore; }
            set { SetProperty(ref isLoadingMore, value); }
        }

        private int itemTreshold = 3;
        public int ItemTreshold
        {
            get { return itemTreshold; }
            set { SetProperty(ref itemTreshold, value); }
        }
        public ObservableCollection<MahwousWeb.Shared.Models.App> Apps { get; set; }


        public Command LoadAppsCommand { get; set; }


        public AppsViewModel()
        {
            Apps = new ObservableCollection<MahwousWeb.Shared.Models.App>();

            LoadAppsCommand = new Command(ExecuteLoadAppsCommand);
        }

        async void ExecuteLoadAppsCommand()
        {
            IsBusy = true;

            try
            {
                Apps.Clear();

                var paginatedResponse = await Repositories.AppsRepository.GetPaginated(paginationDTO);
                var apps = paginatedResponse.Response;
                foreach (var app in apps)
                {
                    Apps.Add(app);
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
