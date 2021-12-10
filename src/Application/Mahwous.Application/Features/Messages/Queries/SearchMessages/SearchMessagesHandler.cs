using AutoMapper;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Identity;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.Messages
{
    public class SearchMessagesHandler : IRequestHandler<SearchMessagesQuery, SearchMessagesResponse>
    {
        private readonly IMessageRepository messageRepository;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public SearchMessagesHandler(IMessageRepository messageRepository, IMapper mapper, IUserService userService)
        {
            this.messageRepository = messageRepository;
            this.mapper = mapper;
            this.userService = userService;
        }

        public async Task<SearchMessagesResponse> Handle(SearchMessagesQuery request, CancellationToken cancellationToken)
        {
            var filter = mapper.Map<MessageFilter>(request);
            var messages = await messageRepository.SearchAsync(filter, request.Pagination, request.SortType);
            
            messages.Items = messages.Items.Reverse();

            var response = mapper.Map<SearchMessagesResponse>(messages);

            // get current user and setup response
            var user = await userService.GetCurrentUser();
            foreach (var message in response.Items)
            {
                message.IsOwner = message.UserId == user.Id;
            }

            return response;
        }
    }
}
