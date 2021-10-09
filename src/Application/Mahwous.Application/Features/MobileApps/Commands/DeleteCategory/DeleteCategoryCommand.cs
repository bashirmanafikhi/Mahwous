using MediatR;

namespace Mahwous.Application.Features.MobileApps
{
    public class DeleteMobileAppCommand : IRequest
    {
        public int Id { get; set; }
    }
}
