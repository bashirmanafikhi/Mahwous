using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Mahwous.Application.Features.Posts
{
    public class UpdatePostCommand : IRequest<int>, IMapTo<Post>
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public IFormFile cover { get; set; }
    }
}
