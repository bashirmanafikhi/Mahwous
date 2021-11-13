using FluentValidation;

namespace Mahwous.Application.Features.MobileApps
{
    public class UpdateMobileAppCommandValidator : AbstractValidator<UpdateMobileAppCommand>
    {
        public UpdateMobileAppCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(300);
        }
    }
}
