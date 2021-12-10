using AutoMapper;
using Mahwous.Core.Exceptions;
using Mahwous.Application.Extensions;
using Mahwous.Core.Entities;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.Messages
{
    public class UpdateMessageHandler : IRequestHandler<UpdateMessageCommand, int>
    {

        private readonly IMessageRepository messageRepository;
        private readonly IFileStorageService fileService;
        private readonly IMapper mapper;

        public UpdateMessageHandler(IMessageRepository messageRepository, IFileStorageService fileService, IMapper mapper)
        {
            this.messageRepository = messageRepository;
            this.fileService = fileService;
            this.mapper = mapper;
        }


        public async Task<int> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
            // get the original object to check existence and to take files urls from it
            var oldMessage = await messageRepository.GetByIdAsync(request.Id);
            if (oldMessage == null)
                throw new NotFoundException("The message is not exist");

            // Mapping
            Message newMessage = mapper.Map<Message>(request);

            // Save Data
            await messageRepository.UpdateAsync(newMessage);
            return newMessage.Id;
        }
    }
}
