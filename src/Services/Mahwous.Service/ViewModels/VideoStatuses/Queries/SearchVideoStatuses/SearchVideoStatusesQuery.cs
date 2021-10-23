using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;
using System.Collections.Generic;

namespace Mahwous.Service.ViewModels.VideoStatuses
{
    public class SearchVideoStatusesQuery
    {
        public VideoFilter Filter { get; set; }
        public PaginationDetails Pagination { get; set; } = new PaginationDetails();
        public StatusSortType? SortType { get; set; }


        public string Query
        {
            get
            {
                List<string> conditions = new List<string>();

                if (SortType != null)
                    conditions.Add($"{nameof(SortType)}={SortType}");

                if (Pagination != null)
                {
                    conditions.Add($"{nameof(Pagination)}.{nameof(Pagination.PageIndex)}={Pagination.PageIndex}");
                    conditions.Add($"{nameof(Pagination)}.{nameof(Pagination.PageSize)}={Pagination.PageSize}");
                }

                if (Filter != null)
                {
                    // Todo: filter query
                }
                return string.Join("&", conditions);
                //return this.ToQueryString("&");
            }
        }
    }
}
