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
            else if (string.IsNullOrWhiteSpace(imageStatus.ImagePath))
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
            if (imageFilter.WithoutCategory)
            {
                imagesQueryable = imagesQueryable.Where(v => v.StatusCategories == null || v.StatusCategories.Count == 0);
            }
            else if (imageFilter.Categories != null && imageFilter.Categories.Count > 0)
            {
                int[] catIds = imageFilter.Categories.Select(c => c.Id).ToArray();

                imagesQueryable = imagesQueryable.Where(image =>
                    image.StatusCategories.Any(sc => catIds.Contains(sc.CategoryId))
                );
            }




            // other general status properties

            imagesQueryable = imagesQueryable.Where(v => v.ViewsCount >= imageFilter.ViewsCount.From && v.ViewsCount <= imageFilter.ViewsCount.To);
            imagesQueryable = imagesQueryable.Where(v => v.DownloadsCount >= imageFilter.DownloadsCount.From && v.DownloadsCount <= imageFilter.DownloadsCount.To);
            imagesQueryable = imagesQueryable.Where(v => v.LikesCount >= imageFilter.LikesCount.From && v.LikesCount <= imageFilter.LikesCount.To);

            imagesQueryable = imagesQueryable.Where(v => v.Date >= imageFilter.Date.From && v.Date <= imageFilter.Date.To);

            imagesQueryable = imagesQueryable.Where(v => v.Visible == imageFilter.Visible);


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
                case SortType.Likes:
                    imagesQueryable = imagesQueryable.OrderByDescending(v => v.LikesCount);
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


        [AllowAnonymous]
        [HttpPost("count")]
        public async Task<ActionResult<FilteredInformations>> Count(ImageFilter imageFilter)
        {

            var imagesQueryable = context.ImageStatuses.AsQueryable();

            // categories filter
            if (imageFilter.WithoutCategory)
            {
                imagesQueryable = imagesQueryable.Where(v => v.StatusCategories == null || v.StatusCategories.Count == 0);
            }
            else if (imageFilter.Categories != null && imageFilter.Categories.Count > 0)
            {
                int[] catIds = imageFilter.Categories.Select(c => c.Id).ToArray();

                imagesQueryable = imagesQueryable.Where(image =>
                    image.StatusCategories.Any(sc => catIds.Contains(sc.CategoryId))
                );
            }




            // other general status properties

            imagesQueryable = imagesQueryable.Where(v => v.ViewsCount >= imageFilter.ViewsCount.From && v.ViewsCount <= imageFilter.ViewsCount.To);
            imagesQueryable = imagesQueryable.Where(v => v.DownloadsCount >= imageFilter.DownloadsCount.From && v.DownloadsCount <= imageFilter.DownloadsCount.To);
            imagesQueryable = imagesQueryable.Where(v => v.LikesCount >= imageFilter.LikesCount.From && v.LikesCount <= imageFilter.LikesCount.To);

            imagesQueryable = imagesQueryable.Where(v => v.Date >= imageFilter.Date.From && v.Date <= imageFilter.Date.To);

            imagesQueryable = imagesQueryable.Where(v => v.Visible == imageFilter.Visible);


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
                case SortType.Likes:
                    imagesQueryable = imagesQueryable.OrderByDescending(v => v.LikesCount);
                    break;
                case SortType.Random:
                    imagesQueryable = imagesQueryable.OrderBy(v => Guid.NewGuid());
                    break;
                default:
                    break;
            }

            FilteredInformations informations = new FilteredInformations();
            informations.StatusesCount = await imagesQueryable.CountAsync();

            informations.DownloadsCount = await imagesQueryable.SumAsync(s => (long)s.DownloadsCount);
            informations.LikesCount = await imagesQueryable.SumAsync(s => (long)s.LikesCount);
            informations.ViewsCount = await imagesQueryable.SumAsync(s => (long)s.ViewsCount);

            informations.CategoriesCount = await context.Categories.Where(c => c.ForImages).CountAsync();

            var categoriesStatusCounts = context.Categories.Where(c => c.ForImages).Select(c => new KeyValuePair<string, int>(c.Name, c.StatusCategories.Where(sc => sc.Status is ImageStatus).Count()));
            informations.CategoriesStatusCounts = new Dictionary<string, int>(categoriesStatusCounts);

            return informations;
        }



        [AllowAnonymous]
        [HttpGet("count")]
        public async Task<ActionResult<FilteredInformations>> Count()
        {
            FilteredInformations informations = new FilteredInformations();
            informations.StatusesCount = await context.ImageStatuses.CountAsync();

            informations.DownloadsCount = await context.ImageStatuses.SumAsync(s => (long)s.DownloadsCount);
            informations.LikesCount = await context.ImageStatuses.SumAsync(s => (long)s.LikesCount);
            informations.ViewsCount = await context.ImageStatuses.SumAsync(s => (long)s.ViewsCount);

            informations.CategoriesCount = await context.Categories.Where(c => c.ForImages).CountAsync();

            var categoriesStatusCounts = context.Categories.Where(c => c.ForImages).Select(c => new KeyValuePair<string, int>(c.Name, c.StatusCategories.Where(sc=>sc.Status is ImageStatus).Count()));
            informations.CategoriesStatusCounts = new Dictionary<string, int>(categoriesStatusCounts);

            return informations;
        }
    }
}
