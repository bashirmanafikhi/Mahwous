using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;

namespace Mahwous.Application.Features.ImageStatuses
{
    public class DownloadImageStatusResponse
    {
        public byte[] ImageFile { get; set; }
        public string FileName { get; set; }
    }
}
