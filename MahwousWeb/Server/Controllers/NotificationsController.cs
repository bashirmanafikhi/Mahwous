using MahwousWeb.Persistent;
using MahwousWeb.API.Controllers.MyControllerBase;
using MahwousWeb.API.Helpers;
using MahwousWeb.Models.Filters;
using MahwousWeb.Models.Models;
using MahwousWeb.Models.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahwousWeb.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : GenericController<Notification, NotificationFilter>
    {
        public NotificationsController(ApplicationDbContext context, IFileStorageService fileStorageService)
            : base(context, fileStorageService) { }


        public override async Task<IActionResult> Put(Notification entity)
        {
            var old = await table.FirstOrDefaultAsync(c => c.Id == entity.Id);

            if (old == null) { return NotFound(); }


            await context.Database.ExecuteSqlInterpolatedAsync($"delete from NotificationApps where NotificationId = {entity.Id}");

            old.Apps = entity.Apps;


            context.Entry(old).CurrentValues.SetValues(entity);

            await context.SaveChangesAsync();
            return NoContent();
        }


        public override async Task<ActionResult<Notification>> Get(int id)
        {
            var notification = await table
                .Include(q => q.Apps)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (notification == null)
            {
                return NotFound();
            }

            return notification;
        }


        [HttpGet("GetLastNotification")]
        public async Task<ActionResult<Notification>> GetLastNotification(string packageName)
        {
            var notification = await table
                .Where(n => n.Apps.Any(na => na.Package == packageName))
                //.Include(q => q.NotificationApps)
                //.ThenInclude(sc => sc.App)
                .OrderByDescending(n => n.Id)
                .FirstOrDefaultAsync();

            if (notification == null)
            {
                return NotFound();
            }

            return notification;
        }




        [HttpPut("IncrementOpened/{id}")]
        public async Task<IActionResult> IncrementOpened(int id)
        {
            Notification notification = await table.FirstOrDefaultAsync(s => s.Id == id);
            notification.OpenedCount++;
            context.SaveChanges();

            return Ok();
        }


        [HttpPut("IncrementRecived/{id}")]
        public async Task<IActionResult> IncrementRecived(int id)
        {
            Notification notification = await table.FirstOrDefaultAsync(s => s.Id == id);
            notification.RecivedCount++;
            context.SaveChanges();

            return Ok();
        }


    }
}
