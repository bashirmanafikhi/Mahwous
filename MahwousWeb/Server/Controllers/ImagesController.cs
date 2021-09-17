using MahwousWeb.Persistent;
using MahwousWeb.Server.Controllers.MyControllerBase;
using MahwousWeb.Server.Helpers;
using MahwousWeb.Models.Filters;
using MahwousWeb.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace MahwousWeb.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : GenericStatusesControllerBase<ImageStatus, ImageFilter>
    {
        public ImagesController(ApplicationDbContext context, IFileStorageService fileStorageService)
            : base(context, fileStorageService) { }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] string serializedObject, [FromForm] IFormFile imageFile)
        {
            ImageStatus image = JsonSerializer.Deserialize<ImageStatus>(serializedObject);

            if (imageFile == null)
                return BadRequest("ملف الصورة مطلوب");

            if (imageFile.Length > 0)
                image.ImagePath = await fileStorageService.SaveFile(imageFile, "jpg", "images");
            else
                image.ImagePath = noImage;

            context.Add(image);
            await context.SaveChangesAsync();   
            return Ok(image.Id);
        }


        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromForm] string serializedObject, [FromForm] IFormFile imageFile)
        {
            ImageStatus image = JsonSerializer.Deserialize<ImageStatus>(serializedObject);

            var oldImageStatus = await context.ImageStatuses.FirstOrDefaultAsync(c => c.Id == image.Id);

            if (oldImageStatus == null) { return NotFound(); }

            if(imageFile != null && imageFile.Length > 0)
            {
                image.ImagePath = await fileStorageService.EditFile(imageFile,
                    "jpg", oldImageStatus.ImagePath);
            }

            await context.Database.ExecuteSqlInterpolatedAsync($"delete from StatusCategories where StatusId = {image.Id}");

            oldImageStatus.StatusCategories = image.StatusCategories;

            context.Entry(oldImageStatus).CurrentValues.SetValues(image);

            await context.SaveChangesAsync();
            return NoContent();
        }


        public override async Task<IActionResult> Delete(int id)
        {
            var image = await context.ImageStatuses.FirstOrDefaultAsync(c => c.Id == id);

            if (image == null) { return NotFound(); }


            if (!string.IsNullOrWhiteSpace(image.ImagePath))
            {
                await fileStorageService.DeleteFile(image.ImagePath);
            }

            context.Remove(image);
            await context.SaveChangesAsync();
            return NoContent();
        }


        [HttpGet("Download/{id}")]
        public async Task<IActionResult> Download(int id)
        {
            var image = await context.ImageStatuses.FirstOrDefaultAsync(c => c.Id == id);

            if (image == null) { return NotFound(); }

            byte[] file = fileStorageService.GetFile(image.ImagePath);

            return File(file, "application/octet-stream", "Mahwous Image " + image.Id+".jpg");
        }

    }
}