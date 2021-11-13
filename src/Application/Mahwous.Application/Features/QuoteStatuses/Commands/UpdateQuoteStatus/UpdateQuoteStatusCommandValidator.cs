using FluentValidation;

namespace Mahwous.Application.Features.QuoteStatuses
{
    public class UpdateQuoteStatusCommandValidator : AbstractValidator<UpdateQuoteStatusCommand>
    {
        public UpdateQuoteStatusCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Content).NotEmpty().MaximumLength(500);
        }
    }
}
