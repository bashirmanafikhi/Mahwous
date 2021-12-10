using AutoMapper;
using Mahwous.Core.Exceptions;
using Mahwous.Application.Extensions;
using Mahwous.Core.Entities;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.Posts
{
    public class UpdatePostHandler : IRequestHandler<UpdatePostCommand, int>
    {

        private readonly IPostRepository postRepository;
        private readonly IFileStorageService fileService;
        private readonly IMapper mapper;

        public UpdatePostHandler(IPostRepository postRepository, IFileStorageService fileService, IMapper mapper)
        {
            this.postRepository = postRepository;
            this.fileService = fileService;
            this.mapper = mapper;
        }


        public async Task<int> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            // get the original object to check existence and to take files urls from it
            var oldPost = await postRepository.GetByIdAsync(request.Id);
            if (oldPost == null)
                throw new NotFoundException("The post is not exist");

            // Mapping
            Post newPost = mapper.Map<Post>(request);

            // Map the old files urls
            newPost.CoverPath = oldPost.CoverPath;

            // Save Files if a new file comes
            if (request.Cover != null && request.Cover.Length > 0)
            {
                var coverFile = request.Cover.ToMemoryStream();
                newPost.CoverPath = await fileService.EditFile(newPost.CoverPath, coverFile, Core.Enums.FileType.Image);
            }

            // Save Data
            await postRepository.UpdateAsync(newPost);
            return newPost.Id;
        }
    }
}
