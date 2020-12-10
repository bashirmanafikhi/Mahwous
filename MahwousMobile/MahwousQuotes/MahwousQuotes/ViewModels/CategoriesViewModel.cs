using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MahwousQuotes.ViewModels
{
    public class CategoriesViewModel : BaseViewModel
    {
        public ObservableCollection<CategoryViewModel> Categories { get; set; }
        public Command LoadCategoriesCommand { get; set; }

        public CategoriesViewModel()
        {
            Title = "التصنيفات";
            Categories = new ObservableCollection<CategoryViewModel>();

            LoadCategoriesCommand = new Command(async () => await ExecuteLoadCategoriesCommand());
            GetInformationsCommand = new Command(ExecuteGetInformationsCommand);
        }

        async Task ExecuteLoadCategoriesCommand()
        {
            IsBusy = true;

            try
            {
                Categories.Clear();
                CategoryFilter filter = new CategoryFilter() { ForQuotes = true };

                var paginatedResponse = await Repositories.CategoriesRepository.GetFiltered(filter);
                var categories = paginatedResponse.Response;


                // randomize
                Random rng = new Random();
                categories = categories.OrderBy(item => rng.Next()).ToList();

                // add to the list
                foreach (var category in categories)
                {
                    Categories.Add(new CategoryViewModel(category, Informations.CategoriesStatusCounts[category.Name]));
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
                Informations = await Repositories.QuotesRepository.GetInformations();
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