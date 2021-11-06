using FluentValidation;

namespace Mahwous.Application.Features.ChatRooms
{
    public class DeleteChatRoomCommandValidator : AbstractValidator<DeleteChatRoomCommand>
    {
        public DeleteChatRoomCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}