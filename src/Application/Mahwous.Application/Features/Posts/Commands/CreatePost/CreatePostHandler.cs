using AutoMapper;
using Mahwous.Application.Extensions;
using Mahwous.Core.Entities;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.Posts
{
    public class CreatePostHandler : IRequestHandler<CreatePostCommand, int>
    {

        private readonly IPostRepository postRepository;
        private readonly IFileStorageService fileService;
        private readonly IMapper mapper;

        public CreatePostHandler(IPostRepository postRepository, IFileStorageService fileService, IMapper mapper)
        {
            this.postRepository = postRepository;
            this.fileService = fileService;
            this.mapper = mapper;
        }


        public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            // Mapping
            Post post = mapper.Map<Post>(request);

            // Save Files
            var coverFile = request.Cover.ToMemoryStream();
            post.CoverPath = await fileService.SaveFile(coverFile, Core.Enums.FileType.Image);

            // Save Data
            await postRepository.AddAsync(post);
            return post.Id;
        }
    }
}
