using FluentValidation;

namespace Mahwous.Application.Features.MobileApps
{
    public class CreateMobileAppCommandValidator : AbstractValidator<CreateMobileAppCommand>
    {
        public CreateMobileAppCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(300);
        }
    }
}
