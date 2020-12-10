using MahwousWeb.Server.Controllers.MyControllerBase;
using MahwousWeb.Server.Data;
using MahwousWeb.Server.Helpers;
using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MahwousWeb.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class VideosController : GenericStatusesControllerBase<VideoStatus, VideoFilter>
    {
        public VideosController(ApplicationDbContext context, IFileStorageService fileStorageService)
            : base(context, fileStorageService) { }


        //[HttpPost]
        //[Authorize]
        public override async Task<ActionResult<int>> Post(VideoStatus video)
        {
            if (video is VideoStatus &&
                !string.IsNullOrWhiteSpace(video.CoverPath))
            {
                var coverPath = Convert.FromBase64String(video.CoverPath);
                video.CoverPath = await fileStorageService.SaveFile(coverPath, "jpg", "video_covers");
            }
            else if (string.IsNullOrWhiteSpace(video.CoverPath))
            {
                video.CoverPath = noImage;
            }

            if (video is VideoStatus &&
                !string.IsNullOrWhiteSpace(video.VideoPath))
            {
                var videoPath = Convert.FromBase64String(video.VideoPath);
                video.VideoPath = await fileStorageService.SaveFile(videoPath, "mp4", "videos");
            }



            context.Add(video);
            await context.SaveChangesAsync();
            return video.Id;
        }

        //[HttpPut]
        //[Authorize]
        public override async Task<IActionResult> Put(VideoStatus video)
        {
            var oldStatus = await context.VideoStatuses.FirstOrDefaultAsync(c => c.Id == video.Id);

            if (oldStatus == null) { return NotFound(); }


            if (video is VideoStatus &&
                !string.IsNullOrWhiteSpace((video as VideoStatus).CoverPath) &&
                !(video as VideoStatus).CoverPath.Equals((oldStatus as VideoStatus).CoverPath))
            {
                var coverPath = Convert.FromBase64String((video as VideoStatus).CoverPath);
                (video as VideoStatus).CoverPath = await fileStorageService.EditFile(coverPath,
                    "jpg", (oldStatus as VideoStatus).CoverPath);
            }

            if (video is VideoStatus &&
                !string.IsNullOrWhiteSpace((video as VideoStatus).VideoPath) &&
                !(video as VideoStatus).VideoPath.Equals((oldStatus as VideoStatus).VideoPath))
            {
                var videoPath = Convert.FromBase64String((video as VideoStatus).VideoPath);
                (video as VideoStatus).VideoPath = await fileStorageService.EditFile(videoPath,
                    "mp4", (oldStatus as VideoStatus).VideoPath);
            }





            await context.Database.ExecuteSqlInterpolatedAsync($"delete from StatusCategories where StatusId = {video.Id}");

            oldStatus.StatusCategories = video.StatusCategories;



            context.Entry(oldStatus).CurrentValues.SetValues(video);

            await context.SaveChangesAsync();
            return NoContent();
        }

        //[HttpDelete("{id}")]
        //[Authorize]
        public override async Task<IActionResult> Delete(int id)
        {
            var video = await context.VideoStatuses.FirstOrDefaultAsync(c => c.Id == id);

            if (video == null) { return NotFound(); }


            if (!string.IsNullOrWhiteSpace(video.CoverPath))
            {
                await fileStorageService.DeleteFile(video.CoverPath);
            }

            if (!string.IsNullOrWhiteSpace(video.VideoPath))
            {
                await fileStorageService.DeleteFile(video.VideoPath);
            }

            context.Remove(video);
            await context.SaveChangesAsync();
            return NoContent();
        }

        //[HttpGet("GetInformations")]
        //public override async Task<ActionResult<Informations>> GetInformations()
        //{
        //    return await GetVideosInformations();
        //}


        //[HttpPost("GetInformationsFiltered")]
        //public override async Task<ActionResult<Informations>> GetInformations(VideoFilter filter)
        //{ 
        //    return await GetVideosInformations(filter); 
        //}
        
        ////[NonAction]
        ////public override async Task<ActionResult<Informations>> GetInformations(IFilter<VideoStatus> filter)
        ////{
        ////    return await GetVideosInformations(filter);
        ////}

        //private async Task<Informations> GetVideosInformations(IFilter<VideoStatus> filter = null)
        //{
        //    var videos = context.VideoStatuses.Filter(filter);
        //    Informations informations = new Informations();
        //    informations.Count = await videos.CountAsync();

        //    informations.DownloadsCount = await videos.SumAsync(s => (long)s.DownloadsCount);
        //    informations.LikesCount = await videos.SumAsync(s => (long)s.LikesCount);
        //    informations.ViewsCount = await videos.SumAsync(s => (long)s.ViewsCount);

        //    var categoriesStatusCounts = context.Categories.Where(c => c.ForVideos).Select(c => new KeyValuePair<string, int>(c.Name, c.StatusCategories.Where(sc => sc.Status is VideoStatus).Count()));
        //    informations.CategoriesStatusCounts = new Dictionary<string, int>(categoriesStatusCounts);

        //    return informations;
        //}


        [HttpGet("Download/{id}")]
        public async Task<IActionResult> Download(int id)
        {
            var video = await context.VideoStatuses.FirstOrDefaultAsync(c => c.Id == id);

            if (video == null) { return NotFound(); }

            byte[] file = fileStorageService.GetFile(video.VideoPath);

            return File(file, "application/octet-stream", "Mahwous Video " + video.Id + ".mp4");
        }
    }
}
