namespace MahwousWeb.Models.Models
{
    public class Post : ModelBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }

        //public int ViewsCount { get; set; }
        public int DownloadsCount { get; set; }
        public int LikesCount { get; set; }
    }
}
