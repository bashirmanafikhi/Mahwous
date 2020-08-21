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
    public class AppsController : ControllerBase
    {
        private readonly string noImage = "https://www.mahwous.com/website/images/no_image.jpg";

        private readonly ApplicationDbContext context;
        private readonly IFileStorageService fileStorageService;

        public AppsController(ApplicationDbContext context,
            IFileStorageService fileStorageService)
        {
            this.context = context;
            this.fileStorageService = fileStorageService;
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetApps")]
        public async Task<ActionResult<List<App>>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            var queryable = context.Apps.AsQueryable();
            await HttpContext.InsertPaginationParametersInResponse(queryable, paginationDTO.RecordsPerPage);
            return await queryable.Paginate(paginationDTO).ToListAsync();

        }


        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetApp")]
        public async Task<ActionResult<App>> Get(int id)
        {
            return await context.Apps.FirstOrDefaultAsync(c => c.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(App app)
        {
            if (!string.IsNullOrWhiteSpace(app.ImagePath))
            {
                var appCover = Convert.FromBase64String(app.ImagePath);
                app.ImagePath = await fileStorageService.SaveFile(appCover, "jpg", "apps");
            }
            else
            {
                app.ImagePath = noImage;
            }

            context.Add(app);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetApp", new { id = app.Id }, app);
        }

        [HttpPut]
        public async Task<ActionResult> Put(App app)
        {
            var oldApp = await context.Apps.FirstOrDefaultAsync(c => c.Id == app.Id);

            if (oldApp == null) { return NotFound(); }


            if (!string.IsNullOrWhiteSpace(app.ImagePath) &&
                !app.ImagePath.Equals(oldApp.ImagePath))
            {
                var appCover = Convert.FromBase64String(app.ImagePath);
                app.ImagePath = await fileStorageService.EditFile(appCover,
                    "jpg", "apps", oldApp.ImagePath);
            }

            context.Entry(oldApp).CurrentValues.SetValues(app);

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var app = await context.Apps.FirstOrDefaultAsync(c => c.Id == id);

            if (app == null) { return NotFound(); }


            if (!string.IsNullOrWhiteSpace(app.ImagePath))
            {
                await fileStorageService.DeleteFile(app.ImagePath, "apps");
            }

            context.Remove(app);
            await context.SaveChangesAsync();
            return NoContent();
        }


    }
}
