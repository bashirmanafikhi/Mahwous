using System.IO;

namespace Mahwous.Service.ViewModels.Categories
{
    public class UpdateCategoryCommand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool ForVideos { get; set; } = true;
        public bool ForImages { get; set; } = true;
        public bool ForQuotes { get; set; } = true;

        public Stream Cover { get; set; }
    }
}
