using FluentValidation;

namespace Mahwous.Application.Features.VideoStatuses
{
    public class UpdateVideoStatusCommandValidator : AbstractValidator<UpdateVideoStatusCommand>
    {
        public UpdateVideoStatusCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
        }
    }
}
