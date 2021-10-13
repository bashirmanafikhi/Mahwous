using Mahwous.Core.Entities;
using System.IO;

namespace Mahwous.Service.ViewModels.Posts
{
    public class UpdatePostCommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public Stream Cover { get; set; }
    }
}
