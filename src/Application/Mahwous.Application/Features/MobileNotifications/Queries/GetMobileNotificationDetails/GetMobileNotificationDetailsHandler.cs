using AutoMapper;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.MobileNotifications
{
    public class GetMobileNotificationDetailsHandler : IRequestHandler<GetMobileNotificationDetailsQuery, GetMobileNotificationDetailsResponse>
    {
        private readonly INotificationRepository notificationRepository;
        private readonly IMapper mapper;

        public GetMobileNotificationDetailsHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            this.notificationRepository = notificationRepository;
            this.mapper = mapper;
        }

        public async Task<GetMobileNotificationDetailsResponse> Handle(GetMobileNotificationDetailsQuery request, CancellationToken cancellationToken)
        {
            var notification = await notificationRepository.GetByIdAsync(request.Id);
            var response = mapper.Map<GetMobileNotificationDetailsResponse>(notification);
            return response;
        }
    }
}
