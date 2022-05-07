﻿using Mahwous.Core.Entities;
using Mahwous.Core.General;
using System.Collections.Generic;
using System.Linq;

namespace Mahwous.Core.Filters
{
    public abstract class StatusFilter<T> : EntityFilter<T>, IFilter<T> where T : Status
    {
        public StatusFilter()
        {
            CategoryIds = new List<int>();

            DownloadsCount = new Range<int>();
            DownloadsCount.To = int.MaxValue;

            LikesCount = new Range<int>();
            LikesCount.To = int.MaxValue;

            SharesCount = new Range<int>();
            SharesCount.To = int.MaxValue;

            WithoutCategory = false;
        }

        public IList<int> CategoryIds { get; set; }

        public Range<int> DownloadsCount { get; set; }
        public Range<int> LikesCount { get; set; }
        public Range<int> SharesCount { get; set; }

        public bool WithoutCategory { get; set; }



        public override IQueryable<T> FilterOtherEntityProperties(IQueryable<T> queryable)
        {
            // categories filter
            if (WithoutCategory)
            {
                queryable = queryable.Where(v => v.Categories == null || v.Categories.Count == 0);
            }
            else if (CategoryIds != null && CategoryIds.Count > 0)
            {
                queryable = queryable.Where(video =>
                    video.Categories.Any(sc => CategoryIds.Contains(sc.Id))
                );
            }

            // other general status properties

            queryable = queryable.Where(v => v.DownloadsCount >= DownloadsCount.From && v.DownloadsCount <= DownloadsCount.To);
            queryable = queryable.Where(v => v.LikesCount >= LikesCount.From && v.LikesCount <= LikesCount.To);
            queryable = queryable.Where(v => v.SharesCount >= SharesCount.From && v.SharesCount <= SharesCount.To);


            return queryable;
        }

        // Template Method Design Pattern
        public abstract IQueryable<T> FilterOtherStatusProperties(IQueryable<T> queryable);
    }
}
