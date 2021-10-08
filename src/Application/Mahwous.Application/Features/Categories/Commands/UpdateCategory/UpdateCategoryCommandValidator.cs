using FluentValidation;

namespace Mahwous.Application.Features.Categories
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Content).NotEmpty().MaximumLength(300);
        }
    }
}
