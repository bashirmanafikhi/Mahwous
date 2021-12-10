using Mahwous.Core.Exceptions;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.ChatRooms
{
    public class DeleteChatRoomHandler : IRequestHandler<DeleteChatRoomCommand>
    {

        private readonly IChatRoomRepository chatRoomRepository;
        private readonly IFileStorageService fileService;

        public DeleteChatRoomHandler(IChatRoomRepository chatRoomRepository, IFileStorageService fileService)
        {
            this.chatRoomRepository = chatRoomRepository;
            this.fileService = fileService;
        }

        public async Task<Unit> Handle(DeleteChatRoomCommand request, CancellationToken cancellationToken)
        {
            // get the entity to check existence and to take files urls from it
            var chatRoom = await chatRoomRepository.GetByIdAsync(request.Id);
            if (chatRoom == null)
                throw new NotFoundException("The chatRoom is not exist");

            // Delete Files
            await fileService.DeleteFile(chatRoom.CoverPath);

            // Delete data
            await chatRoomRepository.DeleteAsync(chatRoom.Id);
            return Unit.Value;
        }
    }
}
