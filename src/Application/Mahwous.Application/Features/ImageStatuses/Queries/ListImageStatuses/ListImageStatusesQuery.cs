using Mahwous.Application.Interfaces;
using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using MediatR;

namespace Mahwous.Application.Features.ImageStatuses
{
    public class ListImageStatusesQuery : IListStatusQuery<ImageStatus, ImageFilter, ListImageStatusesResponse>
    {
        public ImageFilter Filter { get; set; }
        public StatusSortType SortType { get; set; } = StatusSortType.Random;
    }
}
