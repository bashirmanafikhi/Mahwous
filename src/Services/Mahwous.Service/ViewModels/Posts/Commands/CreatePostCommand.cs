using System.IO;

namespace Mahwous.Service.ViewModels.Posts
{
    public class CreatePostCommand
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public Stream Cover { get; set; }
    }
}
