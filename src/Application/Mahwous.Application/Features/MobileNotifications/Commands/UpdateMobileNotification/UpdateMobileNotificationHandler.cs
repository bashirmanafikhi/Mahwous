using AutoMapper;
using Mahwous.Core.Exceptions;
using Mahwous.Core.Entities;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.MobileNotifications
{
    public class UpdateMobileNotificationHandler : IRequestHandler<UpdateMobileNotificationCommand, int>
    {

        private readonly INotificationRepository notificationRepository;
        private readonly IFileStorageService fileService;
        private readonly IMapper mapper;

        public UpdateMobileNotificationHandler(INotificationRepository notificationRepository, IFileStorageService fileService, IMapper mapper)
        {
            this.notificationRepository = notificationRepository;
            this.fileService = fileService;
            this.mapper = mapper;
        }


        public async Task<int> Handle(UpdateMobileNotificationCommand request, CancellationToken cancellationToken)
        {
            // check existence
            var exist = await notificationRepository.AnyAsync(x => x.Id == request.Id);
            if (!exist)
                throw new NotFoundException("The notification is not exist");

            // Mapping
            MobileNotification notification = mapper.Map<MobileNotification>(request);

            // Save Data
            await notificationRepository.UpdateAsync(notification);
            return notification.Id;
        }
    }
}
