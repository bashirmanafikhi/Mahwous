using FluentValidation;

namespace Mahwous.Application.Features.VideoStatuses
{
    public class UpdateVideoStatusCommandValidator : AbstractValidator<UpdateVideoStatusCommand>
    {
        public UpdateVideoStatusCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Content).NotEmpty().MaximumLength(300);
        }
    }
}
