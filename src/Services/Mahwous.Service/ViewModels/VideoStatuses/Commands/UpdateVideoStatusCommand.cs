using System.IO;

namespace Mahwous.Service.ViewModels.VideoStatuses
{
    public class UpdateVideoStatusCommand
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Stream Cover { get; set; }
        public Stream Video { get; set; }
    }
}
