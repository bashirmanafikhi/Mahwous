using System.ComponentModel.DataAnnotations;

namespace MahwousWeb.Models.Models
{
    public class Post : ModelBase
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public string ImagePath { get; set; }

        public int DownloadsCount { get; set; }
        public int LikesCount { get; set; }
    }
}
