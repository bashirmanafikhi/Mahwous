using FluentValidation;

namespace Mahwous.Application.Features.Posts
{
    public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
    {
        public UpdatePostCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Content).NotEmpty().MaximumLength(300);
        }
    }
}
