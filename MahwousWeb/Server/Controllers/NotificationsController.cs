using AutoMapper;
using MahwousWeb.Server.Data;
using MahwousWeb.Server.Helpers;
using MahwousWeb.Shared;
using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahwousWeb.Server.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IFileStorageService fileStorageService;

        public NotificationsController(ApplicationDbContext context,
            IFileStorageService fileStorageService)
        {
            this.context = context;
            this.fileStorageService = fileStorageService;
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetNotifications")]
        public async Task<ActionResult<List<Notification>>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            var queryable = context.Notifications.AsQueryable();
            await HttpContext.InsertPaginationParametersInResponse(queryable, paginationDTO.RecordsPerPage);
            return await queryable.Paginate(paginationDTO).ToListAsync();

        }


        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetNotification")]
        public async Task<ActionResult<Notification>> Get(int id)
        {
            return await context.Notifications.FirstOrDefaultAsync(c => c.Id == id);
        }


        [AllowAnonymous]
        [HttpGet("GetLastNotification", Name = "GetLastNotification")]
        public async Task<ActionResult<Notification>> GetLastNotification()
        {
            return await context.Notifications.OrderByDescending(n => n.Id).FirstOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Notification notification)
        {
            context.Add(notification);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetNotification", new { id = notification.Id }, notification);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Notification notification)
        {
            var oldNotification = await context.Notifications.FirstOrDefaultAsync(c => c.Id == notification.Id);

            if (oldNotification == null) { return NotFound(); }


            context.Entry(oldNotification).CurrentValues.SetValues(notification);

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var notification = await context.Notifications.FirstOrDefaultAsync(c => c.Id == id);

            if (notification == null) { return NotFound(); }

            context.Remove(notification);
            await context.SaveChangesAsync();
            return NoContent();
        }


        [HttpPost("IncreaseOpenedCount")]
        public async Task<ActionResult> IncreaseOpenedCount(Notification notification)
        {
            var myNotification = await context.Notifications.FirstOrDefaultAsync(n => n.Id == notification.Id);

            if (myNotification == null) { return NotFound(); }

            myNotification.OpenedCount++;

            await context.SaveChangesAsync();
            return Ok();
        }



        [HttpPost("IncreaseRecivedCount")]
        public async Task<ActionResult> IncreaseRecivedCount(Notification notification)
        {
            var myNotification = await context.Notifications.FirstOrDefaultAsync(n => n.Id == notification.Id);

            if (myNotification == null) { return NotFound(); }

            myNotification.RecivedCount++;

            await context.SaveChangesAsync();
            return Ok();
        }


    }
}
