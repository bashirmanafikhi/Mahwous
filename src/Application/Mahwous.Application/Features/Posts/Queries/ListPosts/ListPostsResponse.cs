using AutoMapper;
using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Mahwous.Application.Features.Posts
{
    public class ListPostsResponse : IHaveCustomMappings
    {
        public List<Post> Posts { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<List<Post>, ListPostsResponse>()
                .ForMember(x => x.Posts, opt => opt.MapFrom(y => y));
        }
    }
}
