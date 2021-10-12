using Mahwous.Application.Mappings;
using Mahwous.Core.Filters;
using MediatR;

namespace Mahwous.Application.Features.VideoStatuses
{
    public class ListVideoStatusesQuery : VideoFilter, IMapTo<VideoFilter>, IRequest<ListVideoStatusesResponse>
    {

    }
}
