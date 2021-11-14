using FluentValidation;

namespace Mahwous.Application.Features.ExternalLinks
{
    public class CreateExternalLinkCommandValidator : AbstractValidator<CreateExternalLinkCommand>
    {
        public CreateExternalLinkCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(300);
        }
    }
}
