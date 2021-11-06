using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using System.Collections.Generic;

namespace Mahwous.Service.ViewModels.Categories
{
    public class ListCategoriesQuery
    {
        public CategoryFilter Filter { get; set; }
        public EntitySortType? SortType { get; set; }

        public string Query
        {
            get
            {
                List<string> conditions = new List<string>();

                if (SortType != null)
                    conditions.Add($"{nameof(SortType)}={SortType}");

                if (Filter != null)
                {
                    if (Filter.ForImages)
                        conditions.Add($"{nameof(Filter)}.{nameof(Filter.ForImages)}={Filter.ForImages}");
                    if (Filter.ForQuotes)
                        conditions.Add($"{nameof(Filter)}.{nameof(Filter.ForQuotes)}={Filter.ForQuotes}");
                    if (Filter.ForVideos)
                        conditions.Add($"{nameof(Filter)}.{nameof(Filter.ForVideos)}={Filter.ForVideos}");

                    // Todo: filter query
                }

                return string.Join("&", conditions);
            }
        }
    }
}
