using MediatR;

namespace Mahwous.Application.Features.VideoStatuses
{
    public class DownloadVideoStatusQuery : IRequest<DownloadVideoStatusResponse>
    {
        public int Id { get; set; }
    }
}
