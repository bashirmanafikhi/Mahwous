using AutoMapper;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Identity;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.Messages
{
    public class ListMessagesHandler : IRequestHandler<ListMessagesQuery, ListMessagesResponse>
    {
        private readonly IMessageRepository messageRepository;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public ListMessagesHandler(IMessageRepository messageRepository, IMapper mapper, IUserService userService)
        {
            this.messageRepository = messageRepository;
            this.mapper = mapper;
            this.userService = userService;
        }

        public async Task<ListMessagesResponse> Handle(ListMessagesQuery request, CancellationToken cancellationToken)
        {
            var filter = mapper.Map<MessageFilter>(request);
            var messages = await messageRepository.ListAllAsync(filter);
            var response = mapper.Map<ListMessagesResponse>(messages);

            // get current user and setup response
            var user = await userService.GetCurrentUser();
            foreach (var message in response)
            {
                bool isOwner = message.UserId == user.Id;
                message.IsOwner = isOwner;
            }

            return response;
        }
    }
}
