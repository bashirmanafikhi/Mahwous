using AutoMapper;
using MahwousWeb.Server.Data;
using MahwousWeb.Server.Helpers;
using MahwousWeb.Shared;
using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MahwousWeb.Server.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly string noImage = "https://www.mahwous.com/website/images/no_image.jpg";

        private readonly ApplicationDbContext context;
        private readonly IFileStorageService fileStorageService;

        public ImagesController(ApplicationDbContext context,
            IFileStorageService fileStorageService)
        {
            this.context = context;
            this.fileStorageService = fileStorageService;
        }



        [AllowAnonymous]
        [HttpGet(Name = "GetImages")]
        public async Task<ActionResult<List<ImageStatus>>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            var queryable = context.ImageStatuses.AsQueryable();
            await HttpContext.InsertPaginationParametersInResponse(queryable, paginationDTO.RecordsPerPage);
            return await queryable.Paginate(paginationDTO).ToListAsync();

        }



        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetImage")]
        public async Task<ActionResult<ImageStatus>> Get(int id)
        {
            var image = await context.ImageStatuses
                .Include(i => i.StatusCategories).ThenInclude(sc => sc.Category)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (image == null)
            {
                return NotFound();
            }

            return image;
        }




        [HttpPost]
        public async Task<ActionResult> Post(ImageStatus imageStatus)
        {
            if (imageStatus is ImageStatus &&
                !string.IsNullOrWhiteSpace(imageStatus.ImagePath))
            {
                var imagePath = Convert.FromBase64String(imageStatus.ImagePath);
                imageStatus.ImagePath = await fileStorageService.SaveFile(imagePath, "jpg", "images");
            }
            else if(string.IsNullOrWhiteSpace(imageStatus.ImagePath))
            {
                imageStatus.ImagePath = noImage;
            }



            context.Add(imageStatus);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetImage", new { id = imageStatus.Id }, imageStatus);
        }


        [HttpPut]
        public async Task<ActionResult> Put(ImageStatus imageStatus)
        {
            var oldImage = await context.ImageStatuses.FirstOrDefaultAsync(i => i.Id == imageStatus.Id);

            if (oldImage == null) { return NotFound(); }


            if (!string.IsNullOrWhiteSpace(imageStatus.ImagePath) &&
                !imageStatus.ImagePath.Equals(oldImage.ImagePath))
            {
                var imagePath = Convert.FromBase64String(imageStatus.ImagePath);
                imageStatus.ImagePath = await fileStorageService.EditFile(imagePath,
                    "jpg", "images", oldImage.ImagePath);
            }



            await context.Database.ExecuteSqlInterpolatedAsync($"delete from StatusCategories where StatusId = {imageStatus.Id}");

            oldImage.StatusCategories = imageStatus.StatusCategories;

            context.Entry(oldImage).CurrentValues.SetValues(imageStatus);

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var imageStatus = await context.ImageStatuses.FirstOrDefaultAsync(i => i.Id == id);
            if (imageStatus == null) { return NotFound(); }

            if (imageStatus is ImageStatus &&
                !string.IsNullOrWhiteSpace(imageStatus.ImagePath))
            {
                await fileStorageService.DeleteFile(imageStatus.ImagePath, "images");
            }



            context.Remove(imageStatus);
            await context.SaveChangesAsync();
            return NoContent();
        }



        [AllowAnonymous]
        [HttpPost("filter")]
        public async Task<ActionResult<List<ImageStatus>>> Filter(ImageFilter imageFilter)
        {

            var imagesQueryable = context.ImageStatuses.AsQueryable();

            // categories filter
            if(imageFilter.Categories != null && imageFilter.Categories.Count > 0)
            {
                int[] catIds = imageFilter.Categories.Select(c => c.Id).ToArray();

                imagesQueryable = imagesQueryable.Where(image =>
                    image.StatusCategories.Any(sc => catIds.Contains(sc.CategoryId))
                );
            }
            



            // other general status properties

            imagesQueryable = imagesQueryable.Where(v => v.ViewsCount >= imageFilter.ViewsCount);
            imagesQueryable = imagesQueryable.Where(v => v.DownloadsCount >= imageFilter.DownloadsCount);
            imagesQueryable = imagesQueryable.Where(v => v.LikesCount >= imageFilter.LikesCount);

            if (imageFilter.Visible)
                imagesQueryable = imagesQueryable.Where(v => v.Visible);

            if (imageFilter.DateFrom != DateTime.MinValue)
                imagesQueryable = imagesQueryable.Where(v => v.Date > imageFilter.DateFrom);
            if (imageFilter.DateTo != DateTime.MinValue)
                imagesQueryable = imagesQueryable.Where(v => v.Date < imageFilter.DateTo);

            switch (imageFilter.SortType)
            {
                case SortType.Newest:
                    imagesQueryable = imagesQueryable.OrderByDescending(v => v.Date);
                    break;
                case SortType.Oldest:
                    imagesQueryable = imagesQueryable.OrderBy(v => v.Date);
                    break;
                case SortType.Views:
                    imagesQueryable = imagesQueryable.OrderByDescending(v => v.ViewsCount);
                    break;
                case SortType.Downloads:
                    imagesQueryable = imagesQueryable.OrderByDescending(v => v.DownloadsCount);
                    break;
                case SortType.Random:
                    imagesQueryable = imagesQueryable.OrderBy(v => Guid.NewGuid());
                    break;
                default:
                    break;
            }

            await HttpContext.InsertPaginationParametersInResponse(imagesQueryable,
                imageFilter.RecordsPerPage);

            var images = await imagesQueryable.Paginate(imageFilter.Pagination).ToListAsync();

            return images;
        }
    }
}
