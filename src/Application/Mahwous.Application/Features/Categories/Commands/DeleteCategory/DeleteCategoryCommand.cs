using MediatR;

namespace Mahwous.Application.Features.Categories
{
    public class DeleteCategoryCommand : IRequest
    {
        public int Id { get; set; }
    }
}
