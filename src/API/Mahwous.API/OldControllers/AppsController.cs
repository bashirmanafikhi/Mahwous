//using Mahwous.Core.Entities;
//using Mahwous.Core.Filters;
//using Mahwous.API.Controllers.MyControllerBase;
//using MahwousWeb.Persistent;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Text.Json;
//using System.Threading.Tasks;
//using Mahwous.Core.Interfaces;
//using Mahwous.Application.Extensions;

//namespace Mahwous.API.Controllers
//{

//    [ApiController]
//    [Route("api/[controller]")]
//    public class AppsController : GenericControllerBase<MobileApp, MobileAppFilter>
//    {
//        public AppsController(ApplicationDbContext context, IFileStorageService fileStorageService)
//            : base(context, fileStorageService) { }

//        [Authorize]
//        [HttpPost]
//        public async Task<ActionResult<int>> Post([FromForm] string serializedObject, [FromForm] IFormFile coverFile)
//        {
//            MobileApp app = JsonSerializer.Deserialize<MobileApp>(serializedObject);

//            if (coverFile != null && coverFile.Length > 0)
//            {
//                app.ImagePath = await fileStorageService.SaveFile(coverFile.ToMemoryStream(), Core.Enums.FileType.Image);
//            }
//            else
//            {
//                app.ImagePath = noImage;
//            }

//            context.Add(app);
//            await context.SaveChangesAsync();
//            return app.Id;
//        }

//        [Authorize]
//        [HttpPut]
//        public async Task<ActionResult<int>> Put([FromForm] string serializedObject, [FromForm] IFormFile coverFile)
//        {
//            MobileApp app = JsonSerializer.Deserialize<MobileApp>(serializedObject);
//            var oldApp = await context.MobileApps.FirstOrDefaultAsync(c => c.Id == app.Id);

//            if (oldApp == null) { return NotFound(); }


//            if (coverFile != null && coverFile.Length > 0)
//            {
//                app.ImagePath = await fileStorageService.EditFile(oldApp.ImagePath, coverFile.ToMemoryStream(), Core.Enums.FileType.Image);
//            }

//            context.Entry(oldApp).CurrentValues.SetValues(app);

//            await context.SaveChangesAsync();
//            return NoContent();
//        }

//        public override async Task<IActionResult> Delete(int id)
//        {
//            var app = await context.MobileApps.FirstOrDefaultAsync(c => c.Id == id);

//            if (app == null) { return NotFound(); }


//            if (!string.IsNullOrWhiteSpace(app.ImagePath))
//            {
//                fileStorageService.DeleteFile(app.ImagePath);
//            }

//            context.Remove(app);
//            await context.SaveChangesAsync();
//            return NoContent();
//        }
//    }
//}
