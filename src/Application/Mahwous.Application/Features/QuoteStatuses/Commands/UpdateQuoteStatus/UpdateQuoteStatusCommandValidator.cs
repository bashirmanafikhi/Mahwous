using FluentValidation;

namespace Mahwous.Application.Features.QuoteStatuses
{
    public class UpdateQuoteStatusCommandValidator : AbstractValidator<UpdateQuoteStatusCommand>
    {
        public UpdateQuoteStatusCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Content).NotEmpty().MaximumLength(300);
        }
    }
}
