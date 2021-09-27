using MahwousMobile.Base.Models;
using Mahwous.Core.Models;

namespace MahwousMobile.Base.ViewModels
{
    // Todo: initialize category count
    public class CategoryViewModel : BaseViewModel
    {
        public MahwousWeb.Models.Models.Category Category { get; set; }

        int statusCount;
        public int StatusCount
        {
            get { return statusCount; }
            set { SetProperty(ref statusCount, value); }
        }

        public StatusType? StatusType { get; set; }

        public CategoryViewModel(MahwousWeb.Models.Models.Category category, int statusCount, StatusType? statusType = null)
        {
            StatusType = statusType;
            StatusCount = statusCount;
            Category = category;
            //Category = Repositories.CategoryRepository.GetCategoriesFiltered(new CategoryFilter() { RecordsPerPage = 1 }).Result.Response[0];
        }
    }
}

