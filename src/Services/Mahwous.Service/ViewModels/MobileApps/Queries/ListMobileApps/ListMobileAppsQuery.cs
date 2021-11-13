using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using System.Collections.Generic;

namespace Mahwous.Service.ViewModels.MobileApps
{
    public class ListMobileAppsQuery
    {
        public MobileAppFilter Filter { get; set; }
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
                    // Todo: filter query
                }

                return string.Join("&", conditions);
            }
        }
    }
}
