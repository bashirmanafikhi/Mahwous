using FluentValidation;

namespace Mahwous.Application.Features.QuoteStatuses
{
    public class CreateQuoteStatusCommandValidator : AbstractValidator<CreateQuoteStatusCommand>
    {
        public CreateQuoteStatusCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Content).NotEmpty().MaximumLength(300);
        }
    }
}
