using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using MahwousMobile.Base.ViewModels;
using MahwousWeb.Models.Filters;
using MahwousWeb.Models.Models;
using MahwousWeb.Models.Pagination;
using Xamarin.Forms;

namespace MahwousMobile.Base.ViewModels
{

    public class AppsViewModel : BaseViewModel
    {
        readonly PaginationDetails paginationDetails = new PaginationDetails() { RecordsPerPage = 200 };


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
        public ObservableCollection<MahwousWeb.Models.Models.App> Apps { get; set; }


        public Command LoadAppsCommand { get; set; }


        public AppsViewModel()
        {
            Apps = new ObservableCollection<MahwousWeb.Models.Models.App>();

            LoadAppsCommand = new Command(async () => await ExecuteLoadAppsCommand());
        }

        async Task ExecuteLoadAppsCommand()
        {
            IsBusy = true;

            try
            {
                Apps.Clear();
                AppFilter filter = new AppFilter();
                filter.Pagination = paginationDetails;
                filter.SortType = SortType.Random;

                var paginatedResponse = await Repositories.AppsRepository.GetFiltered(filter);
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
