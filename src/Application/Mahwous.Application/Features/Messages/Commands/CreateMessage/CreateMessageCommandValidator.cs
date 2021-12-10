using FluentValidation;

namespace Mahwous.Application.Features.Messages
{
    public class CreateMessageCommandValidator : AbstractValidator<CreateMessageCommand>
    {
        public CreateMessageCommandValidator()
        {
            RuleFor(x => x.Content).NotEmpty().MaximumLength(500);
        }
    }
}
