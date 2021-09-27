using AutoMapper;
using Mahwous.Application.Features.Posts;
using Mahwous.Core.Models;

namespace Mahwous.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Posts
            CreateMap<Post, ListPostsResponse>().ReverseMap();
            CreateMap<Post, GetPostDetailsResponse>().ReverseMap();


        }
    }
}
