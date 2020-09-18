using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using MahwousQuotes.ViewModels;
using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using App =  MahwousWeb.Shared.Models.App;
using MahwousWeb.Shared.Pagination;
using Xamarin.Forms;

namespace MahwousQuotes.ViewModels
{

    public class AppsViewModel : BaseViewModel
    {
        readonly PaginationDTO paginationDTO = new PaginationDTO() { RecordsPerPage = 200};


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
            if (IsBusy)
                return;

            IsBusy = true;

                try
                {
                    Apps.Clear();

                    var paginatedResponse = await Repositories.AppRepository.GetApps(paginationDTO);
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
