using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Mahwous.Application.Features.Categories
{
    public class CreateCategoryCommand : IRequest<int>, IMapTo<Category>
    {
        public string Name { get; set; }

        public bool ForVideos { get; set; } = true;
        public bool ForImages { get; set; } = true;
        public bool ForQuotes { get; set; } = true;

        public IFormFile Cover { get; set; }
    }
}
