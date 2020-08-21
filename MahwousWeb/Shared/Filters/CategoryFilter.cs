using MahwousWeb.Shared.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace MahwousWeb.Shared.Filters
{
    public class CategoryFilter
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public PaginationDTO Pagination
        {
            get { return new PaginationDTO() { Page = Page, RecordsPerPage = RecordsPerPage }; }
        }



        public string Name { get; set; }

        public bool ForVideos { get; set; }
        public bool ForImages { get; set; }
        public bool ForQuotes { get; set; }


    }
}
