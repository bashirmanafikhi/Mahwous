using FluentValidation;

namespace Mahwous.Application.Features.MobileApps
{
    public class DeleteMobileAppCommandValidator : AbstractValidator<DeleteMobileAppCommand>
    {
        public DeleteMobileAppCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}