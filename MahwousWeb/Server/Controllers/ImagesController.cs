using MahwousWeb.Persistent;
using MahwousWeb.Server.Controllers.MyControllerBase;
using MahwousWeb.Server.Helpers;
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

namespace MahwousWeb.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : GenericStatusesControllerBase<ImageStatus, ImageFilter>
    {
        public ImagesController(ApplicationDbContext context, IFileStorageService fileStorageService)
            : base(context, fileStorageService) { }


        //[HttpPost]
        //[Authorize]
        public override async Task<ActionResult<int>> Post(ImageStatus image)
        {
            if (!string.IsNullOrWhiteSpace(image.ImagePath))
            {
                var categoryCover = Convert.FromBase64String(image.ImagePath);
                image.ImagePath = await fileStorageService.SaveFile(categoryCover, "jpg", "images");
            }
            else
            {
                image.ImagePath = noImage;
            }

            context.Add(image);
            await context.SaveChangesAsync();
            return image.Id;
        }

        //[HttpPut]
        //[Authorize]
        public override async Task<IActionResult> Put(ImageStatus image)
        {
            var oldImageStatus = await context.ImageStatuses.FirstOrDefaultAsync(c => c.Id == image.Id);

            if (oldImageStatus == null) { return NotFound(); }


            if (image is ImageStatus &&
                !string.IsNullOrWhiteSpace((image as ImageStatus).ImagePath) &&
                !(image as ImageStatus).ImagePath.Equals((oldImageStatus as ImageStatus).ImagePath))
            {
                var coverPath = Convert.FromBase64String((image as ImageStatus).ImagePath);
                (image as ImageStatus).ImagePath = await fileStorageService.EditFile(coverPath,
                    "jpg", (oldImageStatus as ImageStatus).ImagePath);
            }



            await context.Database.ExecuteSqlInterpolatedAsync($"delete from StatusCategories where StatusId = {image.Id}");

            oldImageStatus.StatusCategories = image.StatusCategories;

            context.Entry(oldImageStatus).CurrentValues.SetValues(image);

            await context.SaveChangesAsync();
            return NoContent();
        }

        //[HttpDelete("{id}")]
        //[Authorize]
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


        
        //[HttpGet("GetInformations")]
        //public override async Task<ActionResult<Informations>> GetInformations()
        //{
        //    return await GetImagesInformations();
        //}


        //[HttpPost("GetInformationsFiltered")]
        //public override async Task<ActionResult<Informations>> GetInformations(ImageFilter filter)
        //{ 
        //    return await GetImagesInformations(filter); 
        //}

        ////[NonAction]
        ////public override async Task<ActionResult<Informations>> GetInformations(IFilter<ImageStatus> filter)
        ////{
        ////    return await GetImagesInformations(filter);
        ////}

        //private async Task<Informations> GetImagesInformations(IFilter<ImageStatus> filter = null)
        //{
        //    var images = context.ImageStatuses.Filter(filter);

        //    Informations informations = new Informations();

        //    informations.Count = await images.CountAsync();
        //    informations.DownloadsCount = await images.SumAsync(s => (long)s.DownloadsCount);
        //    informations.LikesCount = await images.SumAsync(s => (long)s.LikesCount);
        //    informations.ViewsCount = await images.SumAsync(s => (long)s.ViewsCount);


        //    var categoriesStatusCounts = context.Categories.Where(c => c.ForImages).Select(c => new KeyValuePair<string, int>(c.Name, c.StatusCategories.Where(sc => sc.Status is ImageStatus).Count()));
        //    informations.CategoriesStatusCounts = new Dictionary<string, int>(categoriesStatusCounts);

        //    return informations;
        //}


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