using MediatR;

namespace Mahwous.Application.Features.ExternalLinks
{
    public class DeleteExternalLinkCommand : IRequest
    {
        public int Id { get; set; }
    }
}
