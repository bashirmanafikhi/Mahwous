using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Mahwous.Application.Features.QuoteStatuses
{
    public class CreateQuoteStatusCommand : IRequest<int>, IMapTo<QuoteStatus>
    {
        public string Content { get; set; }

        public IFormFile Cover { get; set; }
    }
}
