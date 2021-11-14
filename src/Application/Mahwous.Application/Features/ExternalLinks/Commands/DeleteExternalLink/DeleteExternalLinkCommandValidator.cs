using FluentValidation;

namespace Mahwous.Application.Features.ExternalLinks
{
    public class DeleteExternalLinkCommandValidator : AbstractValidator<DeleteExternalLinkCommand>
    {
        public DeleteExternalLinkCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}