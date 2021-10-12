using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Mahwous.Application.Features.MobileApps
{
    public class CreateMobileAppCommand : IRequest<int>, IMapTo<MobileApp>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Package { get; set; }
        public string PlayStoreLink { get; set; }
        public string AppleStoreLink { get; set; }


        public IFormFile Cover { get; set; }
    }
}
