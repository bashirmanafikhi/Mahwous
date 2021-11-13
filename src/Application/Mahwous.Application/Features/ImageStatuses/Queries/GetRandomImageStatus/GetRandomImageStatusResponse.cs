using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;

namespace Mahwous.Application.Features.ImageStatuses
{
    public class GetRandomImageStatusResponse : GetImageStatusDetailsResponse, IMapFrom<ImageStatus>
    {

    }
}
