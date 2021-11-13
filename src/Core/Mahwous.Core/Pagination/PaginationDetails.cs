namespace Mahwous.Core.Pagination
{
    public class PaginationDetails
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public PaginationDetails()
        {
            PageIndex = 1;
            PageSize = 10;
        }

        public PaginationDetails(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
