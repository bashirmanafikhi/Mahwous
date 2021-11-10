using Mahwous.Core.Filters;
using Mahwous.Core.General;
using Mahwous.Core.Pagination;
using MahwousMobile.Base.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MahwousMobile.Base.ViewModels
{
    public class CategoriesViewModel : BaseViewModel
    {
        public ObservableCollection<CategoryViewModel> Categories { get; set; }
        public Command LoadCategoriesCommand { get; set; }

        public CategoriesViewModel(StatusType? statusType = null)
        {
            StatusType = statusType;
            Title = "التصنيفات";
            Categories = new ObservableCollection<CategoryViewModel>();

            LoadCategoriesCommand = new Command(async () => await ExecuteLoadCategoriesCommand());
            GetInformationsCommand = new Command(ExecuteGetInformationsCommand);
        }

        public StatusType? StatusType { get; set; }

        async Task ExecuteLoadCategoriesCommand()
        {
            if (!StatusType.HasValue) return;
            IsBusy = true;

            try
            {
                Categories.Clear();
                CategoryFilter filter = new CategoryFilter();

                switch (StatusType)
                {
                    case Models.StatusType.Image:
                        filter.ForImages = true;
                        break;
                    case Models.StatusType.Video:
                        filter.ForVideos = true;
                        break;
                    case Models.StatusType.Quote:
                        filter.ForQuotes = true;
                        break;
                    default:
                        break;
                }

                var paginatedResponse = await Repositories.CategoriesRepository.List(filter);
                var categories = paginatedResponse.ToList();

                // randomize
                Random rng = new Random();
                categories = categories.OrderBy(item => rng.Next()).ToList();

                // add to the list
                foreach (var category in categories)
                {
                    Categories.Add(new CategoryViewModel(category, 0, StatusType));
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


        private Informations informations;
        public Informations Informations
        {
            get { return informations; }
            set { SetProperty(ref informations, value); }
        }


        private async void ExecuteGetInformationsCommand()
        {
            IsBusy = true;
            try
            {
                //switch (StatusType)
                //{
                //    case Models.StatusType.Image:
                //        Informations = await Repositories.ImageStatusRepository.GetInformations();
                //        break;
                //    case Models.StatusType.Video:
                //        Informations = await Repositories.VideoStatusRepository.GetInformations();
                //        break;
                //    case Models.StatusType.Quote:
                //        Informations = await Repositories.QuoteStatusRepository.GetInformations();
                //        break;
                //    default:
                //        Informations = await Repositories.StatusRepository.GetInformations();
                //        break;
                //}
                Informations = new Informations();

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
        public ICommand GetInformationsCommand { get; }

    }
}