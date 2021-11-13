using System.IO;

namespace Mahwous.Service.ViewModels.VideoStatuses
{
    public class CreateVideoStatusCommand
    {
        public string Title { get; set; }

        public Stream Cover { get; set; }
        public Stream Video { get; set; }
    }
}
