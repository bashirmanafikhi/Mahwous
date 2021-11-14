
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using System;

namespace Mahwous.Core.Entities
{
    public class ExternalLink : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ExternalLinkType LinkType { get; set; }
        public string Url { get; set; }
        public string CoverPath { get; set; }
    }
}
