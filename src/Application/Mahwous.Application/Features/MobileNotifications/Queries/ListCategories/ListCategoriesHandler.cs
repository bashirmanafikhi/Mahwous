using AutoMapper;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.MobileNotifications
{
    public class ListMobileNotificationsHandler : IRequestHandler<ListMobileNotificationsQuery, ListMobileNotificationsResponse>
    {
        private readonly INotificationRepository notificationRepository;
        private readonly IMapper mapper;

        public ListMobileNotificationsHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            this.notificationRepository = notificationRepository;
            this.mapper = mapper;
        }

        public async Task<ListMobileNotificationsResponse> Handle(ListMobileNotificationsQuery request, CancellationToken cancellationToken)
        {
            var filter = mapper.Map<MobileNotificationFilter>(request);
            var mobileNotifications = await notificationRepository.ListAllAsync(filter);
            var response = mapper.Map<ListMobileNotificationsResponse>(mobileNotifications);
            return response;
        }
    }
}
