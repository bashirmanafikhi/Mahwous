using FluentValidation;

namespace Mahwous.Application.Features.MobileApps
{
    public class CreateMobileAppCommandValidator : AbstractValidator<CreateMobileAppCommand>
    {
        public CreateMobileAppCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Content).NotEmpty().MaximumLength(300);
        }
    }
}
