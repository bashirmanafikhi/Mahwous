using MediatR;

namespace Mahwous.Application.Features.VideoStatuses
{
    public class GetVideoStatusDetailsQuery : IRequest<GetVideoStatusDetailsResponse>
    {
        public int Id { get; set; }
    }
}
