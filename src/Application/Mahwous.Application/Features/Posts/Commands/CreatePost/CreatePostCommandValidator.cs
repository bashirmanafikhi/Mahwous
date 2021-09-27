using FluentValidation;

namespace Mahwous.Application.Features.Posts
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Content).NotEmpty().MaximumLength(300);
        }
    }
}
