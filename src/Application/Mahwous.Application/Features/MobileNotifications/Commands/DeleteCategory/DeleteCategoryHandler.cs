using Mahwous.Application.Exceptions;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.MobileNotifications
{
    public class DeleteMobileNotificationHandler : IRequestHandler<DeleteMobileNotificationCommand>
    {

        private readonly INotificationRepository notificationRepository;
        private readonly IFileStorageService fileService;

        public DeleteMobileNotificationHandler(INotificationRepository notificationRepository, IFileStorageService fileService)
        {
            this.notificationRepository = notificationRepository;
            this.fileService = fileService;
        }

        public async Task<Unit> Handle(DeleteMobileNotificationCommand request, CancellationToken cancellationToken)
        {
            // check existence
            var exist = await notificationRepository.AnyAsync(x => x.Id == request.Id);
            if (!exist)
                throw new NotFoundException("The notification is not exist");

            // Delete Files

            // Delete data
            await notificationRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
