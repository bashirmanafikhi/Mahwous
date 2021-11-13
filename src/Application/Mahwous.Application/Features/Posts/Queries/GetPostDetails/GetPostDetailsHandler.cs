using AutoMapper;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.Posts
{
    public class GetPostDetailsHandler : IRequestHandler<GetPostDetailsQuery, GetPostDetailsResponse>
    {
        private readonly IPostRepository postRepository;
        private readonly IMapper mapper;

        public GetPostDetailsHandler(IPostRepository postRepository, IMapper mapper)
        {
            this.postRepository = postRepository;
            this.mapper = mapper;
        }

        public async Task<GetPostDetailsResponse> Handle(GetPostDetailsQuery request, CancellationToken cancellationToken)
        {
            var post = await postRepository.GetByIdAsync(request.Id);
            var response = mapper.Map<GetPostDetailsResponse>(post);
            return response;
        }
    }
}
