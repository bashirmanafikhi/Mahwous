﻿using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using MediatR;

namespace Mahwous.Application.Features.Posts
{
    public class UpdatePostCommand : Post, IRequest<int>, IMapTo<Post>
    {

    }
}
