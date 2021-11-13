using AutoMapper;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.Categories
{
    public class ListCategoriesHandler : IRequestHandler<ListCategoriesQuery, ListCategoriesResponse>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public ListCategoriesHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<ListCategoriesResponse> Handle(ListCategoriesQuery request, CancellationToken cancellationToken)
        {
            var filter = mapper.Map<CategoryFilter>(request);
            var categories = await categoryRepository.ListAllAsync(filter);
            var response = mapper.Map<ListCategoriesResponse>(categories);
            return response;
        }
    }
}
