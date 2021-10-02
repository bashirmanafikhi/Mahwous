using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.API.Controllers.MyControllerBase;
using MahwousWeb.Persistent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Threading.Tasks;
using Mahwous.Core.Interfaces;
using Mahwous.Application.Extensions;

namespace Mahwous.API.Controllers
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
                image.ImagePath = await fileStorageService.SaveFile(imageFile.ToMemoryStream(), Core.Enums.FileType.Image);
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

            if (imageFile != null && imageFile.Length > 0)
            {
                image.ImagePath = await fileStorageService.EditFile(oldImageStatus.ImagePath, imageFile.ToMemoryStream(), Core.Enums.FileType.Image);
            }

            await context.Database.ExecuteSqlInterpolatedAsync($"delete from StatusCategories where StatusId = {image.Id}");

            oldImageStatus.Categories = image.Categories;

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

            return File(file, "application/octet-stream", "Mahwous Image " + image.Id + ".jpg");
        }

    }
}