using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Mahwous.Application.Features.MobileNotifications
{
    public class UpdateMobileNotificationCommand : IRequest<int>, IMapTo<MobileNotification>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public IFormFile Cover { get; set; }
    }
}
