using AutoMapper;
using FluentValidation;
using Mahwous.Application.Interfaces.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.Posts
{
    public class DeletePostHandler : IRequestHandler<DeletePostCommand>
    {

        private readonly IPostRepository postRepository;
        private readonly IMapper mapper;

        public DeletePostHandler(IPostRepository postRepository, IMapper mapper)
        {
            this.postRepository = postRepository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            DeletePostCommandValidator validator = new DeletePostCommandValidator();
            var result = await validator.ValidateAsync(request);
            if (result.Errors.Any())
            {
                throw new ValidationException(result.Errors);
            }

            await postRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
