using AutoMapper;
using Mahwous.Application.Exceptions;
using Mahwous.Application.Interfaces.Repositories;
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
            var posts = await postRepository.ListAllAsync();
            var response = mapper.Map<ListPostsResponse>(posts);
            return response;
        }
    }
}
