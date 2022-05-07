using AutoMapper;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.ChatRooms
{
    public class SearchChatRoomsHandler : IRequestHandler<SearchChatRoomsQuery, SearchChatRoomsResponse>
    {
        private readonly IChatRoomRepository chatRoomRepository;
        private readonly IMapper mapper;

        public SearchChatRoomsHandler(IChatRoomRepository chatRoomRepository, IMapper mapper)
        {
            this.chatRoomRepository = chatRoomRepository;
            this.mapper = mapper;
        }

        public async Task<SearchChatRoomsResponse> Handle(SearchChatRoomsQuery request, CancellationToken cancellationToken)
        {
            var filter = mapper.Map<ChatRoomFilter>(request.Filter);
            var chatRooms = await chatRoomRepository.SearchAsync(filter, request.Pagination, request.SortType);
            var response = mapper.Map<SearchChatRoomsResponse>(chatRooms);
            return response;
        }
    }
}
