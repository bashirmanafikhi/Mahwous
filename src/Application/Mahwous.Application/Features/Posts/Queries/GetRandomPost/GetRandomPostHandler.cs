using AutoMapper;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.Posts
{
    public class GetRandomPostHandler : IRequestHandler<GetRandomPostQuery, GetRandomPostResponse>
    {
        private readonly IPostRepository postRepository;
        private readonly IMapper mapper;

        public GetRandomPostHandler(IPostRepository postRepository, IMapper mapper)
        {
            this.postRepository = postRepository;
            this.mapper = mapper;
        }

        public async Task<GetRandomPostResponse> Handle(GetRandomPostQuery request, CancellationToken cancellationToken)
        {
            var post = await postRepository.GetRandomAsync();
            var response = mapper.Map<GetRandomPostResponse>(post);
            return response;
        }
    }
}
