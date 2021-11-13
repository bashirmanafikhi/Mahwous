using Mahwous.Application.Exceptions;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.Categories
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand>
    {

        private readonly ICategoryRepository categoryRepository;
        private readonly IFileStorageService fileService;

        public DeleteCategoryHandler(ICategoryRepository categoryRepository, IFileStorageService fileService)
        {
            this.categoryRepository = categoryRepository;
            this.fileService = fileService;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            // get the entity to check existence and to take files urls from it
            var category = await categoryRepository.GetByIdAsync(request.Id);
            if (category == null)
                throw new NotFoundException("The category is not exist");

            // Delete Files
            await fileService.DeleteFile(category.CoverPath);

            // Delete data
            await categoryRepository.DeleteAsync(category.Id);
            return Unit.Value;
        }
    }
}
