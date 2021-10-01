using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;

namespace Mahwous.Application.Features.Posts
{
    public class CreatePostCommand : IRequest<int>, IMapTo<Post>
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public int DownloadsCount { get; set; }
        public int LikesCount { get; set; }

        public IFormFile cover { get; set; }
    }
}
