using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MahwousMobile.Base.ViewModels
{

    public class ExternalLinksViewModel : BaseViewModel
    {
        PaginationDetails paginationDetails = new PaginationDetails();
        public ExternalLinkFilter ExternalLinkFilter { get; set; } = new ExternalLinkFilter();
        private int totalAmountPages;


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

        public event EventHandler ExternalLinksFinished;

        public ObservableCollection<ExternalLink> ExternalLinks { get; set; }
        public Command LoadExternalLinksCommand { get; set; }
        public Command LoadMoreExternalLinksCommand { get; set; }

        public ExternalLinksViewModel()
        {

            ExternalLinks = new ObservableCollection<ExternalLink>();

            LoadExternalLinksCommand = new Command(async () => await ExecuteLoadExternalLinksCommand());
            LoadMoreExternalLinksCommand = new Command(async () => await ExecuteLoadMoreExternalLinksCommand());
        }


        async Task ExecuteLoadMoreExternalLinksCommand()
        {
            if (!IsLoadingMore)
            {
                IsLoadingMore = true;

                try
                {
                    if (paginationDetails.PageIndex < totalAmountPages)
                    {
                        paginationDetails.PageIndex++;
                        var paginatedResponse = await Repositories.ExternalLinkRepository.Search(paginationDetails, ExternalLinkFilter);
                        foreach (var externalLink in paginatedResponse.Items)
                            ExternalLinks.Add(externalLink);
                    }
                    else
                    {
                        ExternalLinksFinished?.Invoke(this, EventArgs.Empty);
                        ItemTreshold = -1;
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    IsLoadingMore = false;
                }
            }
        }

        async Task ExecuteLoadExternalLinksCommand()
        {
            //if (IsBusy && ExternalLinks.Count == 0)
            //{
            //    return;
            //}

            IsBusy = true;

            try
            {
                ExternalLinks.Clear();
                paginationDetails.PageIndex = 1;

                var paginatedResponse = await Repositories.ExternalLinkRepository.Search(paginationDetails, ExternalLinkFilter);
                totalAmountPages = paginatedResponse.TotalPages;
                var externalLinks = paginatedResponse.Items;
                foreach (var externalLink in externalLinks)
                {
                    ExternalLinks.Add(externalLink);
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
