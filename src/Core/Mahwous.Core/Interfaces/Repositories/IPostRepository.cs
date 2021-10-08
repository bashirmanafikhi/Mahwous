﻿using Mahwous.Core.Entities;
using Mahwous.Core.Filters;

namespace Mahwous.Core.Interfaces.Repositories
{
    public interface IPostRepository : IEntityRepository<Post, PostFilter>
    {

    }
}
