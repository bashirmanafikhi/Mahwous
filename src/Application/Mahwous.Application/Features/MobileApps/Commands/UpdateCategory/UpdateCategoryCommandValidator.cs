using FluentValidation;

namespace Mahwous.Application.Features.MobileApps
{
    public class UpdateMobileAppCommandValidator : AbstractValidator<UpdateMobileAppCommand>
    {
        public UpdateMobileAppCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Content).NotEmpty().MaximumLength(300);
        }
    }
}
