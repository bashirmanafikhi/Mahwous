using FluentValidation;

namespace Mahwous.Application.Features.ChatRooms
{
    public class CreateChatRoomCommandValidator : AbstractValidator<CreateChatRoomCommand>
    {
        public CreateChatRoomCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(300);
        }
    }
}
