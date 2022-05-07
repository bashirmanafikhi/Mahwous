using AutoMapper;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.Categories
{
    public class SearchCategoriesHandler : IRequestHandler<SearchCategoriesQuery, SearchCategoriesResponse>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public SearchCategoriesHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<SearchCategoriesResponse> Handle(SearchCategoriesQuery request, CancellationToken cancellationToken)
        {
            var filter = mapper.Map<CategoryFilter>(request.Filter);
            var categories = await categoryRepository.SearchAsync(filter, request.Pagination, request.SortType);
            var response = mapper.Map<SearchCategoriesResponse>(categories);
            return response;
        }
    }
}
