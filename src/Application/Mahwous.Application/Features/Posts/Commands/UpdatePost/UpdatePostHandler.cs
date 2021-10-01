using AutoMapper;
using FluentValidation;
using Mahwous.Application.Interfaces.Repositories;
using Mahwous.Core.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.Posts
{
    public class UpdatePostHandler : IRequestHandler<UpdatePostCommand, int>
    {

        private readonly IPostRepository postRepository;
        private readonly IMapper mapper;

        public UpdatePostHandler(IPostRepository postRepository, IMapper mapper)
        {
            this.postRepository = postRepository;
            this.mapper = mapper;
        }


        public async Task<int> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            UpdatePostCommandValidator validator = new UpdatePostCommandValidator();
            var result = await validator.ValidateAsync(request);
            if (result.Errors.Any())
            {
                throw new ValidationException(result.Errors);
            }

            Post post = mapper.Map<Post>(request);
            await postRepository.UpdateAsync(post);
            return post.Id;
        }
    }
}
