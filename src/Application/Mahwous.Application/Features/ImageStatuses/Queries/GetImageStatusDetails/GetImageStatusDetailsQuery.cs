using MediatR;

namespace Mahwous.Application.Features.ImageStatuses
{
    public class GetImageStatusDetailsQuery : IRequest<GetImageStatusDetailsResponse>
    {
        public int Id { get; set; }
    }
}
