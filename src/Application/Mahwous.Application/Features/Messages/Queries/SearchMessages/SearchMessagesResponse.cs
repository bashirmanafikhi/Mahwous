using AutoMapper;
using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using Mahwous.Core.Pagination;

namespace Mahwous.Application.Features.Messages
{
    public class SearchMessagesResponse : PaginatedList<GetMessageDetailsResponse>, IHaveCustomMappings
    {
        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<PaginatedList<Message>, SearchMessagesResponse>();
            configuration.CreateMap<Message, GetMessageDetailsResponse>()
                .ForMember(x => x.OwnerName, opt => opt.MapFrom(y => y.User.UserName));
        }
    }
}
