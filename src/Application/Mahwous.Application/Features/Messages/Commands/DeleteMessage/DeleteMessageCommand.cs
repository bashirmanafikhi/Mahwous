using MediatR;

namespace Mahwous.Application.Features.Messages
{
    public class DeleteMessageCommand : IRequest
    {
        public int Id { get; set; }
    }
}
