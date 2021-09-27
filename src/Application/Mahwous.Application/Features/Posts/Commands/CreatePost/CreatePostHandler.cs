using AutoMapper;
using FluentValidation;
using Mahwous.Application.Interfaces.Repositories;
using Mahwous.Core.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.Posts
{
    public class CreatePostHandler : IRequestHandler<CreatePostCommand, int>
    {

        private readonly IPostRepository postRepository;
        private readonly IMapper mapper;

        public CreatePostHandler(IPostRepository postRepository, IMapper mapper)
        {
            this.postRepository = postRepository;
            this.mapper = mapper;
        }


        public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            CreatePostCommandValidator validator = new CreatePostCommandValidator();
            var result = await validator.ValidateAsync(request);
            if (result.Errors.Any())
            {
                throw new ValidationException(result.Errors);
            }

            Post post = mapper.Map<Post>(request);
            await postRepository.AddAsync(post);
            return post.Id;
        }
    }
}
