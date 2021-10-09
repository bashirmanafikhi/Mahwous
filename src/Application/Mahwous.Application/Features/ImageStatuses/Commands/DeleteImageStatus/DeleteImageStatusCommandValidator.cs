using FluentValidation;

namespace Mahwous.Application.Features.ImageStatuses
{
    public class DeleteImageStatusCommandValidator : AbstractValidator<DeleteImageStatusCommand>
    {
        public DeleteImageStatusCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}