using FluentValidation;

namespace Mahwous.Application.Features.ChatRooms
{
    public class UpdateChatRoomCommandValidator : AbstractValidator<UpdateChatRoomCommand>
    {
        public UpdateChatRoomCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(300);
        }
    }
}
