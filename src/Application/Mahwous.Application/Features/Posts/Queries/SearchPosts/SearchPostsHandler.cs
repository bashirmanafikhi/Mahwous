using AutoMapper;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.Posts
{
    public class SearchPostsHandler : IRequestHandler<SearchPostsQuery, SearchPostsResponse>
    {
        private readonly IPostRepository postRepository;
        private readonly IMapper mapper;

        public SearchPostsHandler(IPostRepository postRepository, IMapper mapper)
        {
            this.postRepository = postRepository;
            this.mapper = mapper;
        }

        public async Task<SearchPostsResponse> Handle(SearchPostsQuery request, CancellationToken cancellationToken)
        {
            var filter = mapper.Map<PostFilter>(request);
            var posts = await postRepository.SearchAsync(filter, request.Pagination);
            var response = mapper.Map<SearchPostsResponse>(posts);
            return response;
        }
    }
}
