using AutoMapper;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.MobileApps
{
    public class SearchMobileAppsHandler : IRequestHandler<SearchMobileAppsQuery, SearchMobileAppsResponse>
    {
        private readonly IMobileAppRepository mobileAppRepository;
        private readonly IMapper mapper;

        public SearchMobileAppsHandler(IMobileAppRepository mobileAppRepository, IMapper mapper)
        {
            this.mobileAppRepository = mobileAppRepository;
            this.mapper = mapper;
        }

        public async Task<SearchMobileAppsResponse> Handle(SearchMobileAppsQuery request, CancellationToken cancellationToken)
        {
            var filter = mapper.Map<MobileAppFilter>(request.Filter);
            var mobileApps = await mobileAppRepository.SearchAsync(filter, request.Pagination, request.SortType);
            var response = mapper.Map<SearchMobileAppsResponse>(mobileApps);
            return response;
        }
    }
}
