using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Mahwous.Application.Features.ImageStatuses
{
    public class UpdateImageStatusCommand : IRequest<int>, IMapTo<ImageStatus>
    {
        public int Id { get; set; }
        public IFormFile Image { get; set; }
    }
}
