using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;

namespace Mahwous.Application.Features.VideoStatuses
{
    public class DownloadVideoStatusResponse
    {
        public byte[] VideoFile { get; set; }
        public string FileName { get; set; }
    }
}
