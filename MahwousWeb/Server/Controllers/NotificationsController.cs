using MahwousWeb.Server.Controllers.MyControllerBase;
using MahwousWeb.Server.Data;
using MahwousWeb.Server.Helpers;
using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahwousWeb.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : GenericControllerBase<Notification, NotificationFilter>
    {
        public NotificationsController(ApplicationDbContext context, IFileStorageService fileStorageService)
            : base(context, fileStorageService) { }


        public override async Task<IActionResult> Put(Notification entity)
        {
            var old = await table.FirstOrDefaultAsync(c => c.Id == entity.Id);

            if (old == null) { return NotFound(); }


            await context.Database.ExecuteSqlInterpolatedAsync($"delete from NotificationApps where NotificationId = {entity.Id}");

            old.NotificationApps = entity.NotificationApps;


            context.Entry(old).CurrentValues.SetValues(entity);

            await context.SaveChangesAsync();
            return NoContent();
        }
        //[HttpPost]
        //[Authorize]
        //public override async Task<ActionResult<int>> Post(Notification notification)
        //{
        //    context.Add(notification);
        //    await context.SaveChangesAsync();
        //    return notification.Id;
        //}

        //[HttpPut]
        //[Authorize]
        //public override async Task<IActionResult> Put(Notification notification)
        //{
        //    var oldNotification = await context.Notifications.FirstOrDefaultAsync(c => c.Id == notification.Id);

        //    if (oldNotification == null) { return NotFound(); }

        //    context.Entry(oldNotification).CurrentValues.SetValues(notification);

        //    await context.SaveChangesAsync();
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //[Authorize]
        //public override async Task<IActionResult> Delete(int id)
        //{
        //    var notification = await context.Notifications.FirstOrDefaultAsync(c => c.Id == id);

        //    if (notification == null) { return NotFound(); }


        //    context.Remove(notification);
        //    await context.SaveChangesAsync();
        //    return NoContent();
        //}


        //[HttpGet("GetInformations")]
        //public override async Task<ActionResult<Informations>> GetInformations()
        //{
        //    return await GetNotificationsInformations();
        //}


        //[HttpPost("GetInformationsFiltered")]
        //public async Task<ActionResult<Informations>> GetInformations(NotificationFilter filter)
        //{ return await GetInformations((IFilter<Notification>)filter); }
        //[NonAction]
        //public override async Task<ActionResult<Informations>> GetInformations(IFilter<Notification> filter)
        //{
        //    return await GetNotificationsInformations(filter);
        //}

        //private async Task<Informations> GetNotificationsInformations(IFilter<Notification> filter = null)
        //{
        //    var notifications = context.Notifications.Filter(filter);

        //    Informations informations = new Informations();
        //    informations.Count = await notifications.CountAsync();
        //    informations.ViewsCount = await notifications.SumAsync(s => (long)s.ViewsCount);

        //    return informations;
        //}
    }
}
