using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Mahwous.Application.Features.ExternalLinks
{
    public class UpdateExternalLinkCommand : IRequest<int>, IMapTo<ExternalLink>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ExternalLinkType LinkType { get; set; }
        public string Url { get; set; }

        public IFormFile Cover { get; set; }
    }
}
