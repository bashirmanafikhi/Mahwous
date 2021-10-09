using AutoMapper;
using Mahwous.Application.Exceptions;
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
            // get the original object to check existence and to take files urls from it
            var oldCategory = await categoryRepository.GetByIdAsync(request.Id);
            if (oldCategory == null)
                throw new NotFoundException("The category is not exist");

            // Mapping
            Category newCategory = mapper.Map<Category>(request);

            // Map the old files urls
            newCategory.CoverPath = oldCategory.CoverPath;

            // Save Files if a new file comes
            if (request.Cover != null && request.Cover.Length > 0)
            {
                var coverFile = request.Cover.ToMemoryStream();
                newCategory.CoverPath = await fileService.EditFile(newCategory.CoverPath, coverFile, Core.Enums.FileType.Image);
            }

            // Save Data
            await categoryRepository.UpdateAsync(newCategory);
            return newCategory.Id;
        }
    }
}
