using MahwousWeb.Persistent;
using MahwousWeb.API.Controllers.MyControllerBase;
using MahwousWeb.API.Helpers;
using MahwousWeb.Models.Filters;
using MahwousWeb.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;

namespace MahwousWeb.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AppsController : GenericControllerBase<MobileApp, AppFilter>
    {
        public AppsController(ApplicationDbContext context, IFileStorageService fileStorageService)
            : base(context, fileStorageService) { }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromForm] string serializedObject, [FromForm] IFormFile coverFile)
        {
            MobileApp app = JsonSerializer.Deserialize<MobileApp>(serializedObject);

            if (coverFile != null && coverFile.Length > 0)
            {
                app.ImagePath = await fileStorageService.SaveFile(coverFile, "jpg", "apps");
            }
            else
            {
                app.ImagePath = noImage;
            }

            context.Add(app);
            await context.SaveChangesAsync();
            return app.Id;
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<int>> Put([FromForm] string serializedObject, [FromForm] IFormFile coverFile)
        {
            MobileApp app = JsonSerializer.Deserialize<MobileApp>(serializedObject);
            var oldApp = await context.MobileApps.FirstOrDefaultAsync(c => c.Id == app.Id);

            if (oldApp == null) { return NotFound(); }


            if (coverFile != null && coverFile.Length > 0)
            {
                app.ImagePath = await fileStorageService.EditFile(coverFile,
                    "jpg", oldApp.ImagePath);
            }

            context.Entry(oldApp).CurrentValues.SetValues(app);

            await context.SaveChangesAsync();
            return NoContent();
        }

        public override async Task<IActionResult> Delete(int id)
        {
            var app = await context.MobileApps.FirstOrDefaultAsync(c => c.Id == id);

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
