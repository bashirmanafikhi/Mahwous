using AutoMapper;
using Mahwous.Core.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahwous.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap(typeof(PaginatedList<>), typeof(PaginatedList<>));
        }
    }
}
