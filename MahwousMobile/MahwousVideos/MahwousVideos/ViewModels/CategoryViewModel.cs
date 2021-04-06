using MahwousWeb.Models.Models;

namespace MahwousVideos.ViewModels
{
    // Todo: initialize category count
    public class CategoryViewModel : BaseViewModel
    {
        public Category Category { get; set; }

        int statusCount;
        public int StatusCount
        {
            get { return statusCount; }
            set { SetProperty(ref statusCount, value); }
        }

        public CategoryViewModel(Category category, int statusCount)
        {
            StatusCount = statusCount;
            Category = category;
            //Category = Repositories.CategoryRepository.GetCategoriesFiltered(new CategoryFilter() { RecordsPerPage = 1 }).Result.Response[0];
        }
    }
}

