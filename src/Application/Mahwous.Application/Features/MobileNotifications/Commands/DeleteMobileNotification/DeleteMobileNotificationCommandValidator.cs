using FluentValidation;

namespace Mahwous.Application.Features.MobileNotifications
{
    public class DeleteMobileNotificationCommandValidator : AbstractValidator<DeleteMobileNotificationCommand>
    {
        public DeleteMobileNotificationCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}