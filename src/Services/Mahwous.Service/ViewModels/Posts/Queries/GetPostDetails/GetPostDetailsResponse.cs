﻿using Mahwous.Core.Entities;
using System;

namespace Mahwous.Service.ViewModels.Posts
{
    public class GetPostDetailsResponse
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public DateTime? DeletedAt { get; set; }

        public bool IsHidden { get; set; }
        public int ViewsCount { get; set; }

        public string UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CoverPath { get; set; }

        public int LikesCount { get; set; }
        public int SharesCount { get; set; }
    }
}
