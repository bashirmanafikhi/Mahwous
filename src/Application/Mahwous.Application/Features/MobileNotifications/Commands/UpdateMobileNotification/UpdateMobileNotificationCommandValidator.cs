using FluentValidation;

namespace Mahwous.Application.Features.MobileNotifications
{
    public class UpdateMobileNotificationCommandValidator : AbstractValidator<UpdateMobileNotificationCommand>
    {
        public UpdateMobileNotificationCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(300);
        }
    }
}
