using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace MahwousWeb.Shared.Filters
{
    public class StatusFilter
    {
        public StatusFilter()
        {
            Categories = new List<Category>();
            SortType = SortType.Random;
            Visible = true;
        }

        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;

        public PaginationDTO Pagination
        {
            get { return new PaginationDTO() { Page = Page, RecordsPerPage = RecordsPerPage }; }
        }




        public SortType SortType { get; set; }

        public int ViewsCount { get; set; }
        public int DownloadsCount { get; set; }
        public int LikesCount { get; set; }

        public bool Visible { get; set; } = true;

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }


        public IList<Category> Categories { get; set; }
    }
}
