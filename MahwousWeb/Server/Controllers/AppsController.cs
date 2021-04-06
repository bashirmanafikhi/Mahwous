using MahwousWeb.Persistent;
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
    public class AppsController : GenericControllerBase<App, AppFilter>
    {
        public AppsController(ApplicationDbContext context, IFileStorageService fileStorageService)
            : base(context, fileStorageService) { }


        //[HttpPost]
        //[Authorize]
        public override async Task<ActionResult<int>> Post(App app)
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
            return app.Id;
        }

        //[HttpPut]
        //[Authorize]
        public override async Task<IActionResult> Put(App app)
        {
            var oldApp = await context.Apps.FirstOrDefaultAsync(c => c.Id == app.Id);

            if (oldApp == null) { return NotFound(); }


            if (!string.IsNullOrWhiteSpace(app.ImagePath) &&
                !app.ImagePath.Equals(oldApp.ImagePath))
            {
                var appCover = Convert.FromBase64String(app.ImagePath);
                app.ImagePath = await fileStorageService.EditFile(appCover,
                    "jpg", oldApp.ImagePath);
            }

            context.Entry(oldApp).CurrentValues.SetValues(app);

            await context.SaveChangesAsync();
            return NoContent();
        }

        //[HttpDelete("{id}")]
        //[Authorize]
        public override async Task<IActionResult> Delete(int id)
        {
            var app = await context.Apps.FirstOrDefaultAsync(c => c.Id == id);

            if (app == null) { return NotFound(); }


            if (!string.IsNullOrWhiteSpace(app.ImagePath))
            {
                await fileStorageService.DeleteFile(app.ImagePath);
            }

            context.Remove(app);
            await context.SaveChangesAsync();
            return NoContent();
        }


        //[HttpGet("GetInformations")]
        //public override async Task<ActionResult<Informations>> GetInformations()
        //{
        //    return await GetAppsInformations();
        //}


        //[HttpPost("GetInformationsFiltered")]
        //public async Task<ActionResult<Informations>> GetInformations(AppFilter filter)
        //{ return await GetInformations((IFilter<App>)filter); }
        //[NonAction]
        //public override async Task<ActionResult<Informations>> GetInformations(IFilter<App> filter)
        //{
        //    return await GetAppsInformations(filter);
        //}

        //private async Task<Informations> GetAppsInformations(IFilter<App> filter = null)
        //{
        //    var apps = context.Apps.Filter(filter);

        //    Informations informations = new Informations
        //    {
        //        Count = await apps.CountAsync(),
        //        ViewsCount = await apps.SumAsync(s => (long)s.ViewsCount)
        //    };

        //    return informations;
        //}
    }
}
