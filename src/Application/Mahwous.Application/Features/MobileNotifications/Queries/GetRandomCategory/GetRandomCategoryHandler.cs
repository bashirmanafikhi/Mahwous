using AutoMapper;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.MobileNotifications
{
    public class GetRandomMobileNotificationHandler : IRequestHandler<GetRandomMobileNotificationQuery, GetRandomMobileNotificationResponse>
    {
        private readonly INotificationRepository notificationRepository;
        private readonly IMapper mapper;

        public GetRandomMobileNotificationHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            this.notificationRepository = notificationRepository;
            this.mapper = mapper;
        }

        public async Task<GetRandomMobileNotificationResponse> Handle(GetRandomMobileNotificationQuery request, CancellationToken cancellationToken)
        {
            var notification = await notificationRepository.GetRandomAsync();
            var response = mapper.Map<GetRandomMobileNotificationResponse>(notification);
            return response;
        }
    }
}
