using AutoMapper;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.Categories
{
    public class GetCategoryDetailsHandler : IRequestHandler<GetCategoryDetailsQuery, GetCategoryDetailsResponse>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public GetCategoryDetailsHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<GetCategoryDetailsResponse> Handle(GetCategoryDetailsQuery request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetByIdAsync(request.Id);
            var response = mapper.Map<GetCategoryDetailsResponse>(category);
            return response;
        }
    }
}
