using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Mahwous.Application.Features.Categories
{
    public class UpdateCategoryCommand : IRequest<int>, IMapTo<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool ForVideos { get; set; } = true;
        public bool ForImages { get; set; } = true;
        public bool ForQuotes { get; set; } = true;

        public IFormFile Cover { get; set; }
    }
}
