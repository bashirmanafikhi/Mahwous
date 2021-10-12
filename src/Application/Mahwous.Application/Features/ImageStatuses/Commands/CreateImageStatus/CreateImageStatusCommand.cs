using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Mahwous.Application.Features.ImageStatuses
{
    public class CreateImageStatusCommand : IRequest<int>, IMapTo<ImageStatus>
    {
        public IFormFile Image { get; set; }
    }
}
