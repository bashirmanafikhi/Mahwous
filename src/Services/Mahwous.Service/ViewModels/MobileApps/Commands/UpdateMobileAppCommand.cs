using Mahwous.Core.Entities;
using System.IO;

namespace Mahwous.Service.ViewModels.MobileApps
{
    public class UpdateMobileAppCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Package { get; set; }
        public string PlayStoreLink { get; set; }
        public string AppleStoreLink { get; set; }

        public Stream Cover { get; set; }
    }
}
