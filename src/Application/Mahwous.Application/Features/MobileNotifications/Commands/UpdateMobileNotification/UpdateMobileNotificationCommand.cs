using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Mahwous.Application.Features.MobileNotifications
{
    public class UpdateMobileNotificationCommand : IRequest<int>, IMapTo<MobileNotification>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReturningData { get; set; }
        public int BadgeNumber { get; set; }
        public bool IsScheduled { get; set; }
        public DateTime? NotifyTime { get; set; }

        public List<MobileApp> Apps { get; set; }
        public IFormFile Cover { get; set; }
    }
}
