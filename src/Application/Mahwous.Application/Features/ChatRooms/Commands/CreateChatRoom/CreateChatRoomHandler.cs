using AutoMapper;
using Mahwous.Application.Extensions;
using Mahwous.Core.Entities;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.ChatRooms
{
    public class CreateChatRoomHandler : IRequestHandler<CreateChatRoomCommand, int>
    {

        private readonly IChatRoomRepository chatRoomRepository;
        private readonly IFileStorageService fileService;
        private readonly IMapper mapper;

        public CreateChatRoomHandler(IChatRoomRepository chatRoomRepository, IFileStorageService fileService, IMapper mapper)
        {
            this.chatRoomRepository = chatRoomRepository;
            this.fileService = fileService;
            this.mapper = mapper;
        }


        public async Task<int> Handle(CreateChatRoomCommand request, CancellationToken cancellationToken)
        {
            // Mapping
            ChatRoom chatRoom = mapper.Map<ChatRoom>(request);

            // Save Files
            var coverFile = request.Cover.ToMemoryStream();
            chatRoom.CoverPath = await fileService.SaveFile(coverFile, Core.Enums.FileType.Image);

            // Save Data
            await chatRoomRepository.AddAsync(chatRoom);
            return chatRoom.Id;
        }
    }
}
