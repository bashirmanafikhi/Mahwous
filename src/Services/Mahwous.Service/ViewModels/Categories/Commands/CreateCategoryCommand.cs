using System.IO;

namespace Mahwous.Service.ViewModels.Categories
{
    public class CreateCategoryCommand
    {
        public string Name { get; set; }

        public bool ForVideos { get; set; } = true;
        public bool ForImages { get; set; } = true;
        public bool ForQuotes { get; set; } = true;

        public Stream Cover { get; set; }
    }
}
