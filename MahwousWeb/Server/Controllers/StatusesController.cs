using MahwousWeb.Persistent;
using MahwousWeb.Server.Controllers.MyControllerBase;
using MahwousWeb.Server.Helpers;
using MahwousWeb.Models.Filters;
using MahwousWeb.Models.Models;
using MahwousWeb.Models.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MahwousWeb.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusesController : GenericStatusesControllerBase<Status, StatusFilterBase<Status>>
    {
        public StatusesController(ApplicationDbContext context, IFileStorageService fileStorageService)
            : base(context, fileStorageService) { }




        //[HttpPost]
        //[Authorize]
        //public override async Task<ActionResult<int>> Post(Status status)
        //{
        //    if (status is ImageStatus &&
        //        !string.IsNullOrWhiteSpace((status as ImageStatus).ImagePath))
        //    {
        //        var imagePath = Convert.FromBase64String((status as ImageStatus).ImagePath);
        //        (status as ImageStatus).ImagePath = await fileStorageService.SaveFile(imagePath, "jpg", "images");
        //    }

        //    if (status is VideoStatus &&
        //        !string.IsNullOrWhiteSpace((status as VideoStatus).CoverPath))
        //    {
        //        var coverPath = Convert.FromBase64String((status as VideoStatus).CoverPath);
        //        (status as VideoStatus).CoverPath = await fileStorageService.SaveFile(coverPath, "jpg", "video_covers");
        //    }

        //    if (status is VideoStatus &&
        //        !string.IsNullOrWhiteSpace((status as VideoStatus).VideoPath))
        //    {
        //        var videoPath = Convert.FromBase64String((status as VideoStatus).VideoPath);
        //        (status as VideoStatus).VideoPath = await fileStorageService.SaveFile(videoPath, "mp4", "videos");
        //    }



        //    context.Add(status);
        //    await context.SaveChangesAsync();
        //    return status.Id;
        //}

        //[HttpPut]
        //[Authorize]
        //public override async Task<IActionResult> Put(Status status)
        //{
        //    var oldStatus = await context.Statuses.FirstOrDefaultAsync(c => c.Id == status.Id);

        //    if (oldStatus == null) { return NotFound(); }



        //    if (status is ImageStatus &&
        //        !string.IsNullOrWhiteSpace((status as ImageStatus).ImagePath) &&
        //        !(status as ImageStatus).ImagePath.Equals((oldStatus as ImageStatus).ImagePath))
        //    {
        //        var imagePath = Convert.FromBase64String((status as ImageStatus).ImagePath);
        //        (status as ImageStatus).ImagePath = await fileStorageService.EditFile(imagePath,
        //            "jpg", (oldStatus as ImageStatus).ImagePath);
        //    }




        //    if (status is VideoStatus &&
        //        !string.IsNullOrWhiteSpace((status as VideoStatus).CoverPath) &&
        //        !(status as VideoStatus).CoverPath.Equals((oldStatus as VideoStatus).CoverPath))
        //    {
        //        var coverPath = Convert.FromBase64String((status as VideoStatus).CoverPath);
        //        (status as VideoStatus).CoverPath = await fileStorageService.EditFile(coverPath,
        //            "jpg", (oldStatus as VideoStatus).CoverPath);
        //    }

        //    if (status is VideoStatus &&
        //        !string.IsNullOrWhiteSpace((status as VideoStatus).VideoPath) &&
        //        !(status as VideoStatus).VideoPath.Equals((oldStatus as VideoStatus).VideoPath))
        //    {
        //        var videoPath = Convert.FromBase64String((status as VideoStatus).VideoPath);
        //        (status as VideoStatus).VideoPath = await fileStorageService.EditFile(videoPath,
        //            "mp4", (oldStatus as VideoStatus).VideoPath);
        //    }



        //    await context.Database.ExecuteSqlInterpolatedAsync($"delete from StatusCategories where StatusId = {status.Id}");

        //    oldStatus.StatusCategories = status.StatusCategories;


        //    context.Entry(oldStatus).CurrentValues.SetValues(status);

        //    await context.SaveChangesAsync();
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //[Authorize]
        //public override async Task<IActionResult> Delete(int id)
        //{
        //    var status = await context.Statuses.FirstOrDefaultAsync(c => c.Id == id);

        //    if (status == null) { return NotFound(); }

        //    if (status is ImageStatus &&
        //        !string.IsNullOrWhiteSpace((status as ImageStatus).ImagePath))
        //    {
        //        await fileStorageService.DeleteFile((status as ImageStatus).ImagePath);
        //    }

        //    if (status is VideoStatus &&
        //        !string.IsNullOrWhiteSpace((status as VideoStatus).CoverPath))
        //    {
        //        await fileStorageService.DeleteFile((status as VideoStatus).CoverPath);
        //    }

        //    if (status is VideoStatus &&
        //        !string.IsNullOrWhiteSpace((status as VideoStatus).VideoPath))
        //    {
        //        await fileStorageService.DeleteFile((status as VideoStatus).VideoPath);
        //    }

        //    context.Remove(status);
        //    await context.SaveChangesAsync();
        //    return NoContent();
        //}






        //[HttpGet("GetInformations")]
        //public override async Task<ActionResult<Informations>> GetInformations()
        //{
        //    return await GetStatusesInformations();
        //}


        //[HttpPost("GetInformationsFiltered")]
        //public override async Task<ActionResult<Informations>> GetInformations(StatusFilter filter)
        //{
        //    return await GetStatusesInformations(filter);
        //}

        //private async Task<Informations> GetStatusesInformations(IFilter<Status> filter = null)
        //{
        //    var statuses = context.Statuses.Filter(filter);
        //    Informations informations = new Informations();

        //    informations.Count = await statuses.CountAsync();

        //    informations.LikesCount = await statuses.SumAsync(s => (long)s.LikesCount);
        //    informations.DownloadsCount = await statuses.SumAsync(s => (long)s.DownloadsCount);
        //    informations.SharesCount = await statuses.SumAsync(s => (long)s.SharesCount);
        //    informations.ViewsCount = await statuses.SumAsync(s => (long)s.ViewsCount);


        //    var categoriesStatusCounts = context.Categories.Select(c => new KeyValuePair<string, int>(c.Name, c.StatusCategories.Count));
        //    informations.CategoriesStatusCounts = new Dictionary<string, int>(categoriesStatusCounts);

        //    return informations;
        //}


        ////---------------------- not implementaion methods -------------------------



        //[HttpPut("IncrementDownloads/{id}")]
        //public async Task<IActionResult> IncrementDownloads(int id)
        //{
        //    Status status = await context.Statuses.FirstOrDefaultAsync(s => s.Id == id);
        //    status.DownloadsCount++;
        //    context.SaveChanges();

        //    return Ok();
        //}

        //[HttpPut("IncrementShares/{id}")]
        //public async Task<IActionResult> IncrementShares(int id)
        //{
        //    Status status = await context.Statuses.FirstOrDefaultAsync(s => s.Id == id);
        //    status.SharesCount++;
        //    context.SaveChanges();

        //    return Ok();
        //}

        //[HttpPut("IncrementLikes/{id}")]
        //public async Task<IActionResult> IncrementLikes(int id)
        //{
        //    Status status = await context.Statuses.FirstOrDefaultAsync(s => s.Id == id);
        //    status.LikesCount++;
        //    context.SaveChanges();

        //    return Ok();
        //}

        //[HttpPut("DecrementLikes/{id}")]
        //public async Task<IActionResult> DecrementLikes(int id)
        //{
        //    Status status = await context.Statuses.FirstOrDefaultAsync(s => s.Id == id);
        //    status.LikesCount--;
        //    context.SaveChanges();

        //    return Ok();
        //}


    }
}
