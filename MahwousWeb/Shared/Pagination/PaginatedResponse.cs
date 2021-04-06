﻿namespace MahwousWeb.Shared.Pagination
{
    public class PaginatedResponse<T>
    {
        public T Response { get; set; }

        public int TotalAmountPages { get; set; }

        public PaginationDetails Pagination { get; set; }
    }
}