using AutoMapper;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.MobileNotifications
{
    public class SearchMobileNotificationsHandler : IRequestHandler<SearchMobileNotificationsQuery, SearchMobileNotificationsResponse>
    {
        private readonly INotificationRepository notificationRepository;
        private readonly IMapper mapper;

        public SearchMobileNotificationsHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            this.notificationRepository = notificationRepository;
            this.mapper = mapper;
        }

        public async Task<SearchMobileNotificationsResponse> Handle(SearchMobileNotificationsQuery request, CancellationToken cancellationToken)
        {
            var filter = mapper.Map<MobileNotificationFilter>(request);
            var mobileNotifications = await notificationRepository.SearchAsync(filter, request.Pagination, request.SortType);
            var response = mapper.Map<SearchMobileNotificationsResponse>(mobileNotifications);
            return response;
        }
    }
}
