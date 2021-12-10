using AutoMapper;
using Mahwous.Application.Extensions;
using Mahwous.Core.Entities;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Identity;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.Messages
{
    public class CreateMessageHandler : IRequestHandler<CreateMessageCommand, int>
    {

        private readonly IMessageRepository messageRepository;
        private readonly IFileStorageService fileService;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public CreateMessageHandler(IMessageRepository messageRepository, IFileStorageService fileService, IMapper mapper, IUserService userService)
        {
            this.messageRepository = messageRepository;
            this.fileService = fileService;
            this.mapper = mapper;
            this.userService = userService;
        }


        public async Task<int> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            // Mapping
            Message message = mapper.Map<Message>(request);

            // Save Data
            await messageRepository.AddAsync(message);

            return message.Id;
        }
    }
}
