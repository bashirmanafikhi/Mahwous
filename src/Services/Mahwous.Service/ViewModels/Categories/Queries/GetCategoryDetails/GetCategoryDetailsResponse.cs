using Mahwous.Core.Entities;
using System;

namespace Mahwous.Service.ViewModels.Categories
{
    public class GetCategoryDetailsResponse
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public DateTime? DeletedAt { get; set; }

        public bool IsHidden { get; set; }
        public int ViewsCount { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public string CoverPath { get; set; }

        public bool ForVideos { get; set; } = true;
        public bool ForImages { get; set; } = true;
        public bool ForQuotes { get; set; } = true;
    }
}
