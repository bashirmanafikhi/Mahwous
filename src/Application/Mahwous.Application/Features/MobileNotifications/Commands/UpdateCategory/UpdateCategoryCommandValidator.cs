using FluentValidation;

namespace Mahwous.Application.Features.MobileNotifications
{
    public class UpdateMobileNotificationCommandValidator : AbstractValidator<UpdateMobileNotificationCommand>
    {
        public UpdateMobileNotificationCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Content).NotEmpty().MaximumLength(300);
        }
    }
}
