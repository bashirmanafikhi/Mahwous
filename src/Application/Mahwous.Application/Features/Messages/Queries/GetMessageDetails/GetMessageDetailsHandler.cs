using AutoMapper;
using Mahwous.Core.Interfaces.Identity;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.Messages
{
    public class GetMessageDetailsHandler : IRequestHandler<GetMessageDetailsQuery, GetMessageDetailsResponse>
    {
        private readonly IMessageRepository messageRepository;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public GetMessageDetailsHandler(IMessageRepository messageRepository, IMapper mapper, IUserService userService)
        {
            this.messageRepository = messageRepository;
            this.mapper = mapper;
            this.userService = userService;
        }

        public async Task<GetMessageDetailsResponse> Handle(GetMessageDetailsQuery request, CancellationToken cancellationToken)
        {
            var message = await messageRepository.GetByIdAsync(request.Id);
            var response = mapper.Map<GetMessageDetailsResponse>(message);
            var user = await userService.GetCurrentUser();
            response.IsOwner = message.UserId == user.Id;
            response.OwnerName = message.UserId;
            return response;
        }
    }
}
