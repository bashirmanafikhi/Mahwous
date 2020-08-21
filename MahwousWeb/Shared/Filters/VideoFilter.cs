using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace MahwousWeb.Shared.Filters
{
    public class VideoFilter : StatusFilter
    {
        public string Name { get; set; }
    }
}
