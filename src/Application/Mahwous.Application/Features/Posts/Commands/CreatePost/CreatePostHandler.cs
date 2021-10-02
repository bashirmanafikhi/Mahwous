using AutoMapper;
using FluentValidation;
using Mahwous.Core.Interfaces.Repositories;
using Mahwous.Core.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mahwous.Core.Interfaces;
using System.IO;
using Mahwous.Application.Extensions;

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
            // Validation
            CreatePostCommandValidator validator = new CreatePostCommandValidator();
            var result = await validator.ValidateAsync(request);
            if (result.Errors.Any())
            {
                throw new ValidationException(result.Errors);
            }

            // Mapping
            Post post = mapper.Map<Post>(request);

            // Save Files
            var coverFile = request.cover.ToMemoryStream();
            post.ImagePath = await fileService.SaveFile(coverFile, Core.Enums.FileType.Image);

            // Save Data
            await postRepository.AddAsync(post);
            return post.Id;
        }
    }
}
