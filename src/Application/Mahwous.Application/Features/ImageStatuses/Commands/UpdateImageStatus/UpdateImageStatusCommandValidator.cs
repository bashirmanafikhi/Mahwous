using FluentValidation;

namespace Mahwous.Application.Features.ImageStatuses
{
    public class UpdateImageStatusCommandValidator : AbstractValidator<UpdateImageStatusCommand>
    {
        public UpdateImageStatusCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Content).NotEmpty().MaximumLength(300);
        }
    }
}
