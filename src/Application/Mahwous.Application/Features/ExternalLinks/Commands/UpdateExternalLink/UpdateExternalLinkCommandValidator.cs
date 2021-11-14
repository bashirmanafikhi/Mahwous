using FluentValidation;

namespace Mahwous.Application.Features.ExternalLinks
{
    public class UpdateExternalLinkCommandValidator : AbstractValidator<UpdateExternalLinkCommand>
    {
        public UpdateExternalLinkCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(300);
        }
    }
}
