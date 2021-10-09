using MediatR;

namespace Mahwous.Application.Features.ImageStatuses
{
    public class DeleteImageStatusCommand : IRequest
    {
        public int Id { get; set; }
    }
}
