using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;

namespace Mahwous.Application.Features.VideoStatuses
{
    public class GetRandomVideoStatusResponse : GetVideoStatusDetailsResponse, IMapFrom<VideoStatus>
    {

    }
}
