using Mahwous.Core.Exceptions;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.Posts
{
    public class DeletePostHandler : IRequestHandler<DeletePostCommand>
    {

        private readonly IPostRepository postRepository;
        private readonly IFileStorageService fileService;

        public DeletePostHandler(IPostRepository postRepository, IFileStorageService fileService)
        {
            this.postRepository = postRepository;
            this.fileService = fileService;
        }

        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            // get the entity to check existence and to take files urls from it
            var post = await postRepository.GetByIdAsync(request.Id);
            if (post == null)
                throw new NotFoundException("The post is not exist");

            // Delete Files
            await fileService.DeleteFile(post.CoverPath);

            // Delete data
            await postRepository.DeleteAsync(post.Id);
            return Unit.Value;
        }
    }
}
