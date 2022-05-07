using Mahwous.Application.Features.QuoteStatuses;
using Mahwous.Application.Interfaces;
using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using MediatR;

namespace Mahwous.Application.Features.VideoStatuses
{
    public class ListVideoStatusesQuery : IListStatusQuery<VideoStatus, VideoFilter, ListVideoStatusesResponse>
    {
        public VideoFilter Filter { get; set; }
        public StatusSortType SortType { get; set; } = StatusSortType.Random;
    }
}
