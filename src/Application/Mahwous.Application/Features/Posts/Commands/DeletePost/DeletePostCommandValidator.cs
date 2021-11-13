using FluentValidation;

namespace Mahwous.Application.Features.Posts
{
    public class DeletePostCommandValidator : AbstractValidator<DeletePostCommand>
    {
        public DeletePostCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}