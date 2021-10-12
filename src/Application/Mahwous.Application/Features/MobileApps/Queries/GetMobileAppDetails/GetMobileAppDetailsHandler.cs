using AutoMapper;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.MobileApps
{
    public class GetMobileAppDetailsHandler : IRequestHandler<GetMobileAppDetailsQuery, GetMobileAppDetailsResponse>
    {
        private readonly IMobileAppRepository mobileAppRepository;
        private readonly IMapper mapper;

        public GetMobileAppDetailsHandler(IMobileAppRepository mobileAppRepository, IMapper mapper)
        {
            this.mobileAppRepository = mobileAppRepository;
            this.mapper = mapper;
        }

        public async Task<GetMobileAppDetailsResponse> Handle(GetMobileAppDetailsQuery request, CancellationToken cancellationToken)
        {
            var mobileApp = await mobileAppRepository.GetByIdAsync(request.Id);
            var response = mapper.Map<GetMobileAppDetailsResponse>(mobileApp);
            return response;
        }
    }
}
