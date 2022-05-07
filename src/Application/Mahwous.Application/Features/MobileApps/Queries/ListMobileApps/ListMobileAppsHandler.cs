using AutoMapper;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.MobileApps
{
    public class ListMobileAppsHandler : IRequestHandler<ListMobileAppsQuery, ListMobileAppsResponse>
    {
        private readonly IMobileAppRepository mobileAppRepository;
        private readonly IMapper mapper;

        public ListMobileAppsHandler(IMobileAppRepository mobileAppRepository, IMapper mapper)
        {
            this.mobileAppRepository = mobileAppRepository;
            this.mapper = mapper;
        }

        public async Task<ListMobileAppsResponse> Handle(ListMobileAppsQuery request, CancellationToken cancellationToken)
        {
            var filter = mapper.Map<MobileAppFilter>(request.Filter);
            var mobileApps = await mobileAppRepository.ListAllAsync(filter);
            var response = mapper.Map<ListMobileAppsResponse>(mobileApps);
            return response;
        }
    }
}
