using MahwousMobile.Base.Models;

namespace MahwousMobile.Base.ViewModels
{
    // Todo: initialize category count
    public class CategoryViewModel : BaseViewModel
    {
        public Mahwous.Core.Entities.Category Category { get; set; }

        int statusCount;
        public int StatusCount
        {
            get { return statusCount; }
            set { SetProperty(ref statusCount, value); }
        }

        public StatusType? StatusType { get; set; }

        public CategoryViewModel(Mahwous.Core.Entities.Category category, int statusCount, StatusType? statusType = null)
        {
            StatusType = statusType;
            StatusCount = statusCount;
            Category = category;
            //Category = Repositories.CategoryRepository.GetCategoriesFiltered(new CategoryFilter() { PageSize = 1 }).Result.Response[0];
        }
    }
}

