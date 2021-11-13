using AutoMapper;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.Categories
{
    public class GetRandomCategoryHandler : IRequestHandler<GetRandomCategoryQuery, GetRandomCategoryResponse>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public GetRandomCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<GetRandomCategoryResponse> Handle(GetRandomCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetRandomAsync();
            var response = mapper.Map<GetRandomCategoryResponse>(category);
            return response;
        }
    }
}
