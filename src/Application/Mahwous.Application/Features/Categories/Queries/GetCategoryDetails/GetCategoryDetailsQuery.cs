using MediatR;

namespace Mahwous.Application.Features.Categories
{
    public class GetCategoryDetailsQuery : IRequest<GetCategoryDetailsResponse>
    {
        public int Id { get; set; }
    }
}
