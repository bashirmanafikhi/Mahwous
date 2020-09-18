using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using MahwousVideos.Models;
using MahwousVideos.Views;
using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using MahwousWeb.Shared.Filters;
using System.Linq;

namespace MahwousVideos.ViewModels
{
    public class CategoriesViewModel : BaseViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }
        public Command LoadCategoriesCommand { get; set; }

        public CategoriesViewModel()
        {
            Title = "التصنيفات";
            LoadCategoriesCommand = new Command(async () => await ExecuteLoadCategoriesCommand());
            Categories = new ObservableCollection<Category>();
        }

        async Task ExecuteLoadCategoriesCommand()
        {
            IsBusy = true;

            try
            {
                Categories.Clear();
                CategoryFilter filter = new CategoryFilter() { ForVideos = true, RecordsPerPage = 100};
                var paginatedResponse = await Repositories.CategoryRepository.GetCategoriesFiltered(filter);
                var categories = paginatedResponse.Response;

                // randomize
                Random rng = new Random();
                categories = categories.OrderBy(item => rng.Next()).ToList();

                // add to the list
                foreach (var category in categories)
                {
                    Categories.Add(category);
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