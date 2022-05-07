using AutoMapper;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.ChatRooms
{
    public class ListChatRoomsHandler : IRequestHandler<ListChatRoomsQuery, ListChatRoomsResponse>
    {
        private readonly IChatRoomRepository chatRoomRepository;
        private readonly IMapper mapper;

        public ListChatRoomsHandler(IChatRoomRepository chatRoomRepository, IMapper mapper)
        {
            this.chatRoomRepository = chatRoomRepository;
            this.mapper = mapper;
        }

        public async Task<ListChatRoomsResponse> Handle(ListChatRoomsQuery request, CancellationToken cancellationToken)
        {
            var filter = mapper.Map<ChatRoomFilter>(request.Filter);
            var chatRooms = await chatRoomRepository.ListAllAsync(filter);
            var response = mapper.Map<ListChatRoomsResponse>(chatRooms);
            return response;
        }
    }
}
