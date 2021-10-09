﻿using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using Mahwous.Core.General;
using System;
using System.Linq;

namespace Mahwous.Core.Filters
{
    public abstract class EntityFilter<T> : IFilter<T> where T : BaseEntity
    {
        // Filter Properties
        public bool? IsHidden { get; set; }
        public Range<int?> ViewsCount { get; set; }
        public Range<DateTime> CreatedDate { get; set; }


        // Constructor
        public EntityFilter()
        {
            IsHidden = true;
            ViewsCount = new Range<int?>();
            CreatedDate = new Range<DateTime>();

            CreatedDate.From = new DateTime(2020, 01, 01);
            CreatedDate.To = DateTime.UtcNow;

            ViewsCount.To = int.MaxValue;
        }

        public IQueryable<T> Filter(IQueryable<T> queryable)
        {
            // Filtering
            if (ViewsCount != null && ViewsCount.From != null)
                queryable = queryable.Where(v => v.ViewsCount >= ViewsCount.From);

            if (ViewsCount != null && ViewsCount.To != null)
                queryable = queryable.Where(v => v.ViewsCount <= ViewsCount.To);

            if (CreatedDate != null && CreatedDate.From != null)
                queryable = queryable.Where(v => v.CreatedDate.Date >= CreatedDate.From.Date);

            if (CreatedDate != null && CreatedDate.To != null)
                queryable = queryable.Where(v => v.CreatedDate.Date <= CreatedDate.To.Date);


            if (IsHidden.HasValue)
            {
                queryable = queryable.Where(v => v.IsHidden == IsHidden);
            }


            queryable = FilterOtherEntityProperties(queryable);

            return queryable;
        }

        public virtual string Query
        {
            get
            {
                return "";
            }
        }


        // Template Method Design Pattern
        public abstract IQueryable<T> FilterOtherEntityProperties(IQueryable<T> queryable);
    }

}
