﻿using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using MediatR;

namespace Mahwous.Application.Features.QuoteStatuses
{
    public class UpdateQuoteStatusCommand : IRequest<int>, IMapTo<QuoteStatus>
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }
}
