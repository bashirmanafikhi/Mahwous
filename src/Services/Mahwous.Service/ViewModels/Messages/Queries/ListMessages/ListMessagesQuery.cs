using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using System.Collections.Generic;

namespace Mahwous.Service.ViewModels.Messages
{
    public class ListMessagesQuery
    {
        public MessageFilter Filter { get; set; }
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
                    if (!string.IsNullOrEmpty(Filter.Content))
                        conditions.Add($"{nameof(Filter.Content)}={Filter.Content}");
                }

                return string.Join("&", conditions);
            }
        }
    }
}
