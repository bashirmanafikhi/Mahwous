using AutoMapper;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.ChatRooms
{
    public class GetRandomChatRoomHandler : IRequestHandler<GetRandomChatRoomQuery, GetRandomChatRoomResponse>
    {
        private readonly IChatRoomRepository chatRoomRepository;
        private readonly IMapper mapper;

        public GetRandomChatRoomHandler(IChatRoomRepository chatRoomRepository, IMapper mapper)
        {
            this.chatRoomRepository = chatRoomRepository;
            this.mapper = mapper;
        }

        public async Task<GetRandomChatRoomResponse> Handle(GetRandomChatRoomQuery request, CancellationToken cancellationToken)
        {
            var chatRoom = await chatRoomRepository.GetRandomAsync();
            var response = mapper.Map<GetRandomChatRoomResponse>(chatRoom);
            return response;
        }
    }
}
