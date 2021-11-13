using AutoMapper;
using Mahwous.Core.Entities;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.MobileNotifications
{
    public class CreateMobileNotificationHandler : IRequestHandler<CreateMobileNotificationCommand, int>
    {

        private readonly INotificationRepository notificationRepository;
        private readonly IFileStorageService fileService;
        private readonly IMapper mapper;

        public CreateMobileNotificationHandler(INotificationRepository notificationRepository, IFileStorageService fileService, IMapper mapper)
        {
            this.notificationRepository = notificationRepository;
            this.fileService = fileService;
            this.mapper = mapper;
        }


        public async Task<int> Handle(CreateMobileNotificationCommand request, CancellationToken cancellationToken)
        {
            // Mapping
            MobileNotification notification = mapper.Map<MobileNotification>(request);

            // Save Files
            //

            // Save Data
            await notificationRepository.AddAsync(notification);
            return notification.Id;
        }
    }
}
