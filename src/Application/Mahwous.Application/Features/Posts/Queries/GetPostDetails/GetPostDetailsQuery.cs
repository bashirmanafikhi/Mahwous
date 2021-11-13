using MediatR;

namespace Mahwous.Application.Features.Posts
{
    public class GetPostDetailsQuery : IRequest<GetPostDetailsResponse>
    {
        public int Id { get; set; }
    }
}
