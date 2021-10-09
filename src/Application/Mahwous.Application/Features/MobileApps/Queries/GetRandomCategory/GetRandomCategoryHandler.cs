using AutoMapper;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.MobileApps
{
    public class GetRandomMobileAppHandler : IRequestHandler<GetRandomMobileAppQuery, GetRandomMobileAppResponse>
    {
        private readonly IMobileAppRepository mobileAppRepository;
        private readonly IMapper mapper;

        public GetRandomMobileAppHandler(IMobileAppRepository mobileAppRepository, IMapper mapper)
        {
            this.mobileAppRepository = mobileAppRepository;
            this.mapper = mapper;
        }

        public async Task<GetRandomMobileAppResponse> Handle(GetRandomMobileAppQuery request, CancellationToken cancellationToken)
        {
            var mobileApp = await mobileAppRepository.GetRandomAsync();
            var response = mapper.Map<GetRandomMobileAppResponse>(mobileApp);
            return response;
        }
    }
}
