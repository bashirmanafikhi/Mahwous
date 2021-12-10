﻿using Mahwous.Core.Entities;
using System;
using System.Collections.Generic;

namespace Mahwous.Service.ViewModels.VideoStatuses
{
    public class GetVideoStatusDetailsResponse
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public DateTime? DeletedAt { get; set; }

        public bool IsHidden { get; set; }
        public int ViewsCount { get; set; }

        public string UserId { get; set; }
        public string Title { get; set; }
        public string VideoPath { get; set; }
        public string CoverPath { get; set; }
        public List<Category> Categories { get; set; }
    }
}
