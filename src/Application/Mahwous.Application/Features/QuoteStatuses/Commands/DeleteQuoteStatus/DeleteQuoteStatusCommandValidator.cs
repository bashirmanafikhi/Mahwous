using FluentValidation;

namespace Mahwous.Application.Features.QuoteStatuses
{
    public class DeleteQuoteStatusCommandValidator : AbstractValidator<DeleteQuoteStatusCommand>
    {
        public DeleteQuoteStatusCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}