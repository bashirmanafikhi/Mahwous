using MediatR;

namespace Mahwous.Application.Features.Posts
{
    public class DeletePostCommand : IRequest
    {
        public int Id { get; set; }
    }
}
