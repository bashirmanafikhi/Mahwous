using FluentValidation;

namespace Mahwous.Application.Features.Reports
{
    public class CreateReportCommandValidator : AbstractValidator<CreateReportCommand>
    {
        public CreateReportCommandValidator()
        {
            RuleFor(x => x.ViolatorId).NotEmpty();
        }
    }
}
