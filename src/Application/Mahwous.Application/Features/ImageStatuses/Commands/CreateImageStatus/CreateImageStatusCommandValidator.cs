using FluentValidation;

namespace Mahwous.Application.Features.ImageStatuses
{
    public class CreateImageStatusCommandValidator : AbstractValidator<CreateImageStatusCommand>
    {
        public CreateImageStatusCommandValidator()
        {
            RuleFor(x => x.Image).Must(x => x.Length > 0);
        }
    }
}
