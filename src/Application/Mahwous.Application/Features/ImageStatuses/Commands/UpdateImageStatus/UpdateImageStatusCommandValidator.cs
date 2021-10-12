using FluentValidation;

namespace Mahwous.Application.Features.ImageStatuses
{
    public class UpdateImageStatusCommandValidator : AbstractValidator<UpdateImageStatusCommand>
    {
        public UpdateImageStatusCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Image).Must(x => x.Length > 0);
        }
    }
}
