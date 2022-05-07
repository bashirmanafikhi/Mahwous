using AutoMapper;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.Posts
{
    public class ListPostsHandler : IRequestHandler<ListPostsQuery, ListPostsResponse>
    {
        private readonly IPostRepository postRepository;
        private readonly IMapper mapper;

        public ListPostsHandler(IPostRepository postRepository, IMapper mapper)
        {
            this.postRepository = postRepository;
            this.mapper = mapper;
        }

        public async Task<ListPostsResponse> Handle(ListPostsQuery request, CancellationToken cancellationToken)
        {
            var filter = mapper.Map<PostFilter>(request.Filter);
            var posts = await postRepository.ListAllAsync(filter);
            var response = mapper.Map<ListPostsResponse>(posts);
            return response;
        }
    }
}
