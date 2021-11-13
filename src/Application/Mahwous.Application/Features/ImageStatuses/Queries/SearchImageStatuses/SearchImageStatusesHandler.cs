using AutoMapper;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.ImageStatuses
{
    public class SearchImageStatusesHandler : IRequestHandler<SearchImageStatusesQuery, SearchImageStatusesResponse>
    {
        private readonly IImageStatusRepository imageRepository;
        private readonly IMapper mapper;

        public SearchImageStatusesHandler(IImageStatusRepository imageRepository, IMapper mapper)
        {
            this.imageRepository = imageRepository;
            this.mapper = mapper;
        }

        public async Task<SearchImageStatusesResponse> Handle(SearchImageStatusesQuery request, CancellationToken cancellationToken)
        {
            var filter = mapper.Map<ImageFilter>(request);
            var imageStatuses = await imageRepository.SearchAsync(filter, request.Pagination, request.SortType);
            var response = mapper.Map<SearchImageStatusesResponse>(imageStatuses);
            return response;
        }
    }
}
