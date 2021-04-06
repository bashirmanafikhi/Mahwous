﻿using MahwousWeb.Persistent;
using MahwousWeb.Server.Controllers.MyControllerBase;
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


        public override async Task<ActionResult<Notification>> Get(int id)
        {
            var notification = await table
                .Include(q => q.NotificationApps)
                .ThenInclude(sc => sc.App)
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
                .Where(n => n.NotificationApps.Any(na => na.App.Package == packageName))
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