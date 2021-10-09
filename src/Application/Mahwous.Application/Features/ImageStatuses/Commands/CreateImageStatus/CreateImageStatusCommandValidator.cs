using FluentValidation;

namespace Mahwous.Application.Features.ImageStatuses
{
    public class CreateImageStatusCommandValidator : AbstractValidator<CreateImageStatusCommand>
    {
        public CreateImageStatusCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Content).NotEmpty().MaximumLength(300);
        }
    }
}
