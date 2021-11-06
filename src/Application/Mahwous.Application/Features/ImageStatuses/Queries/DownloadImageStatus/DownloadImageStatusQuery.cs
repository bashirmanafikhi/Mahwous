using MediatR;

namespace Mahwous.Application.Features.ImageStatuses
{
    public class DownloadImageStatusQuery : IRequest<DownloadImageStatusResponse>
    {
        public int Id { get; set; }
    }
}
