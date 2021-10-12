using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;

namespace Mahwous.Application.Features.MobileApps
{
    public class GetRandomMobileAppResponse : GetMobileAppDetailsResponse, IMapFrom<MobileApp>
    {

    }
}
