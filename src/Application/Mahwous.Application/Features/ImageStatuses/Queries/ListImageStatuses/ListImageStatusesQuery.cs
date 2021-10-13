using Mahwous.Application.Mappings;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using MediatR;

namespace Mahwous.Application.Features.ImageStatuses
{
    public class ListImageStatusesQuery : ImageFilter, IMapTo<ImageFilter>, IRequest<ListImageStatusesResponse>
    {
        public StatusSortType SortType { get; set; } = StatusSortType.Random;
    }
}
