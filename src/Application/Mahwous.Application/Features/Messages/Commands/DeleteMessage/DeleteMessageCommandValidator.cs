using FluentValidation;

namespace Mahwous.Application.Features.Messages
{
    public class DeleteMessageCommandValidator : AbstractValidator<DeleteMessageCommand>
    {
        public DeleteMessageCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}