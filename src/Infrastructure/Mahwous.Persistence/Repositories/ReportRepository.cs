﻿using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;

namespace Mahwous.Persistence.Repositories
{
    public class ReportRepository : EntityRepository<Report, ReportFilter>, IReportRepository
    {
        public ReportRepository(ApplicationDbContext context) : base(context)
        { }

    }
}