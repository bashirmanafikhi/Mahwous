using AutoMapper;
using Mahwous.Application.Extensions;
using Mahwous.Core.Entities;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.Categories
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, int>
    {

        private readonly ICategoryRepository categoryRepository;
        private readonly IFileStorageService fileService;
        private readonly IMapper mapper;
        public UpdateCategoryHandler(ICategoryRepository categoryRepository, IFileStorageService fileService, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.fileService = fileService;
            this.mapper = mapper;
        }


        public async Task<int> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            // Mapping
            Category category = mapper.Map<Category>(request);

            // Save Files
            var coverFile = request.cover.ToMemoryStream();
            category.CoverPath = await fileService.SaveFile(coverFile, Core.Enums.FileType.Image);

            // Save Data
            await categoryRepository.UpdateAsync(category);
            return category.Id;
        }
    }
}
