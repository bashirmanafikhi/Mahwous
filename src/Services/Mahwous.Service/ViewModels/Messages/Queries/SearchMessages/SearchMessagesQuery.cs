using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;
using System.Collections.Generic;

namespace Mahwous.Service.ViewModels.Messages
{
    public class SearchMessagesQuery
    {
        public MessageFilter Filter { get; set; }
        public PaginationDetails Pagination { get; set; } = new PaginationDetails();
        public EntitySortType? SortType { get; set; }


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
                    if (!string.IsNullOrEmpty(Filter.Content))
                        conditions.Add($"{nameof(Filter)}.{nameof(Filter.Content)}={Filter.Content}");
                    if(Filter.RoomId != null)
                        conditions.Add($"{nameof(Filter)}.{nameof(Filter.RoomId)}={Filter.RoomId}");
                }

                return string.Join("&", conditions);
            }
        }
    }
}
