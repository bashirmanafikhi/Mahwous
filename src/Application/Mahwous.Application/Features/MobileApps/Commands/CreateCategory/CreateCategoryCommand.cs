﻿using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Mahwous.Application.Features.MobileApps
{
    public class CreateMobileAppCommand : IRequest<int>, IMapTo<MobileApp>
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public IFormFile cover { get; set; }
    }
}
