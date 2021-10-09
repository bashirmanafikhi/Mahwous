using Mahwous.Application.Mappings;
using Mahwous.Core.Filters;
using MediatR;

namespace Mahwous.Application.Features.ImageStatuses
{
    public class ListImageStatusesQuery : ImageFilter, IMapTo<ImageFilter>, IRequest<ListImageStatusesResponse>
    {

    }
}
