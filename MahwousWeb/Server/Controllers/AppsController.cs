using MahwousWeb.Persistent;
using MahwousWeb.Server.Controllers.MyControllerBase;
using MahwousWeb.Server.Helpers;
using MahwousWeb.Models.Filters;
using MahwousWeb.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MahwousWeb.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AppsController : GenericControllerBase<App, AppFilter>
    {
        public AppsController(ApplicationDbContext context, IFileStorageService fileStorageService)
            : base(context, fileStorageService) { }


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
    }
}
