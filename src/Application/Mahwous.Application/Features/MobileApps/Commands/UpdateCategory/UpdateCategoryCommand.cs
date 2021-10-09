using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Mahwous.Application.Features.MobileApps
{
    public class UpdateMobileAppCommand : IRequest<int>, IMapTo<MobileApp>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public IFormFile Cover { get; set; }
    }
}
