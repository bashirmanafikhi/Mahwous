using FluentValidation;

namespace Mahwous.Application.Features.VideoStatuses
{
    public class DeleteVideoStatusCommandValidator : AbstractValidator<DeleteVideoStatusCommand>
    {
        public DeleteVideoStatusCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}