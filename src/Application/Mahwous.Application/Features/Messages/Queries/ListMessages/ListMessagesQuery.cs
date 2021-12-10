using Mahwous.Application.Mappings;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using MediatR;

namespace Mahwous.Application.Features.Messages
{
    public class ListMessagesQuery : MessageFilter, IMapTo<MessageFilter>, IRequest<ListMessagesResponse>
    {
        public EntitySortType SortType { get; set; } = EntitySortType.Random;
    }
}
