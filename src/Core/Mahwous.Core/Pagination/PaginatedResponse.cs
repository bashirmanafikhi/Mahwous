namespace Mahwous.Core.Pagination
{
    public class PaginatedResponse<T>
    {
        public T Response { get; set; }

        public int TotalAmountPages { get; set; }

        public PaginationDetails Pagination { get; set; }
    }
}
