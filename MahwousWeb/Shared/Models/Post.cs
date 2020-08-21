using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MahwousWeb.Shared.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }

        public int ViewsCount { get; set; }
        public int DownloadsCount { get; set; }
        public int LikesCount { get; set; }

        public bool Visible { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public Post()
        {
            Date = DateTime.Now;
            Visible = true;
        }
    }
}
