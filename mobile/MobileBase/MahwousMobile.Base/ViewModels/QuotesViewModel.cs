using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MahwousMobile.Base.ViewModels
{

    public class QuotesViewModel : BaseViewModel
    {
        private QuoteFilter filter;
        private StatusSortType sortType;
        private PaginationDetails pagination = new PaginationDetails();
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

        public event EventHandler QuotesFinished;


        public ObservableCollection<QuoteViewModel> Quotes { get; set; }
        public Command LoadQuotesCommand { get; set; }
        public Command LoadMoreQuotesCommand { get; set; }
        public QuoteFilter Filter { get => filter; set => filter = value; }
        public StatusSortType SortType { get => sortType; set
            {
                sortType = value;
            }
        }

        public QuotesViewModel(QuoteFilter filter)
        {

            Filter = filter;

            Quotes = new ObservableCollection<QuoteViewModel>();

            LoadQuotesCommand = new Command(async () => await ExecuteLoadQuotesCommand());
            LoadMoreQuotesCommand = new Command(async () => await ExecuteLoadMoreQuotesCommand());

            Title = "اقتباسات";
        }

        public QuotesViewModel() : this(new QuoteFilter()) { }

        async Task ExecuteLoadMoreQuotesCommand()
        {
            if (!IsLoadingMore)
            {
                Debug.WriteLine("Bashir: Loading More");
                IsLoadingMore = true;

                try
                {
                    if (pagination.PageIndex < totalAmountPages)
                    {
                        pagination.PageIndex++;
                        var paginatedResponse = await Repositories.QuoteStatusRepository.Search(pagination, Filter, SortType);
                        foreach (var quote in paginatedResponse.Items)
                            Quotes.Add(new QuoteViewModel(quote));
                    }
                    else
                    {
                        QuotesFinished?.Invoke(this, EventArgs.Empty);
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

        async Task ExecuteLoadQuotesCommand()
        {
            IsBusy = true;

            try
            {
                Quotes.Clear();
                pagination.PageIndex = 1;

                var paginatedResponse = await Repositories.QuoteStatusRepository.Search(pagination, Filter, SortType);
                totalAmountPages = paginatedResponse.TotalPages;
                var quotes = paginatedResponse.Items;
                foreach (var quote in quotes)
                {
                    Quotes.Add(new QuoteViewModel(quote));
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
