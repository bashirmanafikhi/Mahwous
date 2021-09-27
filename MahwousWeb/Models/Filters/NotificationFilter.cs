﻿using Mahwous.Core.Models;
using System.Linq;

namespace MahwousWeb.Models.Filters
{
    public class NotificationFilter : FilterBase<Notification>
    {
        public override IQueryable<Notification> Filter(IQueryable<Notification> queryable)
        {
            queryable = base.Filter(queryable);
            return queryable;
        }
    }
}
