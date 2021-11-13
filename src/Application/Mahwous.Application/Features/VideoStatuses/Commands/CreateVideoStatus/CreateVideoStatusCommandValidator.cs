using FluentValidation;

namespace Mahwous.Application.Features.VideoStatuses
{
    public class CreateVideoStatusCommandValidator : AbstractValidator<CreateVideoStatusCommand>
    {
        public CreateVideoStatusCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
        }
    }
}
