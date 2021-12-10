using MediatR;

namespace Mahwous.Application.Features.Messages
{
    public class GetMessageDetailsQuery : IRequest<GetMessageDetailsResponse>
    {
        public int Id { get; set; }
    }
}
