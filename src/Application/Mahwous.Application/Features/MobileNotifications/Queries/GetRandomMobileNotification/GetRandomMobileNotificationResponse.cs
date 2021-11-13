using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;

namespace Mahwous.Application.Features.MobileNotifications
{
    public class GetRandomMobileNotificationResponse : GetMobileNotificationDetailsResponse, IMapFrom<MobileNotification>
    {

    }
}
