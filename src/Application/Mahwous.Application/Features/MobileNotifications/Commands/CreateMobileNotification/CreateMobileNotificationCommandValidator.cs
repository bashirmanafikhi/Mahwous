using FluentValidation;

namespace Mahwous.Application.Features.MobileNotifications
{
    public class CreateMobileNotificationCommandValidator : AbstractValidator<CreateMobileNotificationCommand>
    {
        public CreateMobileNotificationCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(300);
        }
    }
}
