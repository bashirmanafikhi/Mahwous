using AutoMapper;
using Mahwous.Application.Exceptions;
using Mahwous.Application.Extensions;
using Mahwous.Core.Entities;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.ChatRooms
{
    public class UpdateChatRoomHandler : IRequestHandler<UpdateChatRoomCommand, int>
    {

        private readonly IChatRoomRepository chatRoomRepository;
        private readonly IFileStorageService fileService;
        private readonly IMapper mapper;

        public UpdateChatRoomHandler(IChatRoomRepository chatRoomRepository, IFileStorageService fileService, IMapper mapper)
        {
            this.chatRoomRepository = chatRoomRepository;
            this.fileService = fileService;
            this.mapper = mapper;
        }


        public async Task<int> Handle(UpdateChatRoomCommand request, CancellationToken cancellationToken)
        {
            // get the original object to check existence and to take files urls from it
            var oldChatRoom = await chatRoomRepository.GetByIdAsync(request.Id);
            if (oldChatRoom == null)
                throw new NotFoundException("The chatRoom is not exist");

            // Mapping
            ChatRoom newChatRoom = mapper.Map<ChatRoom>(request);

            // Map the old files urls
            newChatRoom.CoverPath = oldChatRoom.CoverPath;

            // Save Files if a new file comes
            if (request.Cover != null && request.Cover.Length > 0)
            {
                var coverFile = request.Cover.ToMemoryStream();
                newChatRoom.CoverPath = await fileService.EditFile(newChatRoom.CoverPath, coverFile, Core.Enums.FileType.Image);
            }

            // Save Data
            await chatRoomRepository.UpdateAsync(newChatRoom);
            return newChatRoom.Id;
        }
    }
}
