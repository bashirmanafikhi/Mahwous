using Mahwous.Core.Exceptions;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.Messages
{
    public class DeleteMessageHandler : IRequestHandler<DeleteMessageCommand>
    {

        private readonly IMessageRepository messageRepository;
        private readonly IFileStorageService fileService;

        public DeleteMessageHandler(IMessageRepository messageRepository, IFileStorageService fileService)
        {
            this.messageRepository = messageRepository;
            this.fileService = fileService;
        }

        public async Task<Unit> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            // get the entity to check existence and to take files urls from it
            var message = await messageRepository.GetByIdAsync(request.Id);
            if (message == null)
                throw new NotFoundException("The message is not exist");

            // Delete data
            await messageRepository.DeleteAsync(message.Id);
            return Unit.Value;
        }
    }
}
