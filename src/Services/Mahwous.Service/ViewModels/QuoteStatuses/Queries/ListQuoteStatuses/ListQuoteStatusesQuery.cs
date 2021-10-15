using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using System.Collections.Generic;

namespace Mahwous.Service.ViewModels.QuoteStatuses
{
    public class ListQuoteStatusesQuery
    {
        public QuoteFilter Filter { get; set; }
        public StatusSortType? SortType { get; set; }

        public string Query
        {
            get
            {
                List<string> conditions = new List<string>();

                if (SortType != null)
                    conditions.Add($"{nameof(SortType)}={SortType}");

                if (Filter != null)
                {
                    // Todo: filter query
                }

                return string.Join('&', conditions);
            }
        }
    }
}
