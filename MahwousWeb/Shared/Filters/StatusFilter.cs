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

            DownloadsCount = new Range<int>();
            ViewsCount = new Range<int>();
            LikesCount = new Range<int>();
            Date = new Range<DateTime>();

            SortType = SortType.Random;
            Visible = true;
            WithoutCategory = false;

            Date.From = new DateTime(2020, 01, 01);
            Date.To = DateTime.Now;

            DownloadsCount.To = int.MaxValue;
            ViewsCount.To = int.MaxValue;
            LikesCount.To = int.MaxValue;
        }

        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;

        public PaginationDTO Pagination
        {
            get { return new PaginationDTO() { Page = Page, RecordsPerPage = RecordsPerPage }; }
        }




        public SortType SortType { get; set; }

        public Range<int> ViewsCount { get; set; }
        public Range<int> DownloadsCount { get; set; }
        public Range<int> LikesCount { get; set; }

        public Range<DateTime> Date { get; set; }


        public bool Visible { get; set; }
        public bool WithoutCategory { get; set; }

        public IList<Category> Categories { get; set; }
    }



    public enum SortType
    {
        Newest,
        Oldest,
        Views,
        Downloads,
        Likes,
        Random
    }

    public enum Visibility
    {
        Both,
        Visible,
        Invisible
    }

    public class Range<T>
    {
        public T From { get; set; }
        public T To { get; set; }
    }
}
