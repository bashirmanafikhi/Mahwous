using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MahwousMobile.Base.ViewModels
{

    public class AppsViewModel : BaseViewModel
    {
        private PaginationDetails pagination = new PaginationDetails();

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
        public ObservableCollection<Mahwous.Core.Entities.MobileApp> Apps { get; set; }


        public Command LoadAppsCommand { get; set; }


        public AppsViewModel()
        {
            Apps = new ObservableCollection<Mahwous.Core.Entities.MobileApp>();

            LoadAppsCommand = new Command(async () => await ExecuteLoadAppsCommand());
        }

        async Task ExecuteLoadAppsCommand()
        {
            IsBusy = true;

            try
            {
                Apps.Clear();
                MobileAppFilter filter = new MobileAppFilter();

                var paginatedResponse = await Repositories.MobileAppsRepository.Search(pagination, filter);
                var apps = paginatedResponse.Items;
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
