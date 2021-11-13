using AutoMapper;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.ChatRooms
{
    public class GetChatRoomDetailsHandler : IRequestHandler<GetChatRoomDetailsQuery, GetChatRoomDetailsResponse>
    {
        private readonly IChatRoomRepository chatRoomRepository;
        private readonly IMapper mapper;

        public GetChatRoomDetailsHandler(IChatRoomRepository chatRoomRepository, IMapper mapper)
        {
            this.chatRoomRepository = chatRoomRepository;
            this.mapper = mapper;
        }

        public async Task<GetChatRoomDetailsResponse> Handle(GetChatRoomDetailsQuery request, CancellationToken cancellationToken)
        {
            var chatRoom = await chatRoomRepository.GetByIdAsync(request.Id);
            var response = mapper.Map<GetChatRoomDetailsResponse>(chatRoom);
            return response;
        }
    }
}
