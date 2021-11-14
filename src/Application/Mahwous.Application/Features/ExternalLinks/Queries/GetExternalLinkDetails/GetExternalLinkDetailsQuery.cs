using MediatR;

namespace Mahwous.Application.Features.ExternalLinks
{
    public class GetExternalLinkDetailsQuery : IRequest<GetExternalLinkDetailsResponse>
    {
        public int Id { get; set; }
    }
}
