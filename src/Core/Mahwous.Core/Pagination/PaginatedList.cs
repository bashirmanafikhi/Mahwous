using System;
using System.Collections.Generic;
using System.Linq;

namespace Mahwous.Core.Pagination
{
    public class PaginatedList<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public PaginatedList(IEnumerable<T> items, int totalCount, int pageIndex = 1, int pageSize = 10)
            : this(items, totalCount, new PaginationDetails(pageIndex, pageSize))
        {

        }

        public PaginatedList(IEnumerable<T> items, int totalCount, PaginationDetails pagination)
        {
            if (pagination == null) pagination = new PaginationDetails();

            PageIndex = pagination.PageIndex;
            PageSize = pagination.PageSize;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pagination.PageSize);
            TotalCount = totalCount;
            Items = items;
        }

        public PaginatedList()
        {
        }

        public static PaginatedList<T> Create(IEnumerable<T> source, int pageIndex = 1, int pageSize = 10)
        {
            var totalCount = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return new PaginatedList<T>(items, totalCount, pageIndex, pageSize);
        }

        public static PaginatedList<T> Create(IEnumerable<T> source, PaginationDetails pagination)
        {
            if (pagination == null) pagination = new PaginationDetails();
            return Create(source, pagination.PageIndex, pagination.PageSize);
        }
    }
}
