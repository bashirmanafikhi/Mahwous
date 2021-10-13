﻿using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Mahwous.Application.Features.VideoStatuses
{
    public class CreateVideoStatusCommand : IRequest<int>, IMapTo<VideoStatus>
    {
        public string Title { get; set; }

        public IFormFile Cover { get; set; }
        public IFormFile Video { get; set; }
    }
}