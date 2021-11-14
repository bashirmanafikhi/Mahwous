using Mahwous.Core.Enums;
using System.IO;

namespace Mahwous.Service.ViewModels.ExternalLinks
{
    public class UpdateExternalLinkCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ExternalLinkType LinkType { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public Stream Cover { get; set; }
    }
}
