using MediatR;

namespace Mahwous.Application.Features.VideoStatuses
{
    public class DeleteVideoStatusCommand : IRequest
    {
        public int Id { get; set; }
    }
}
