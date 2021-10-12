using MediatR;

namespace Mahwous.Application.Features.MobileApps
{
    public class GetMobileAppDetailsQuery : IRequest<GetMobileAppDetailsResponse>
    {
        public int Id { get; set; }
    }
}
