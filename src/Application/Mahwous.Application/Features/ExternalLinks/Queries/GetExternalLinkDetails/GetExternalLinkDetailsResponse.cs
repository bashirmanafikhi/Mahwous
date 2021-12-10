using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using System;

namespace Mahwous.Application.Features.ExternalLinks
{
    public class GetExternalLinkDetailsResponse : IMapFrom<ExternalLink>
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public DateTime? DeletedAt { get; set; }

        public bool IsHidden { get; set; }
        public int ViewsCount { get; set; }

        public string UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ExternalLinkType LinkType { get; set; }
        public string Url { get; set; }
        public string CoverPath { get; set; }
    }
}
