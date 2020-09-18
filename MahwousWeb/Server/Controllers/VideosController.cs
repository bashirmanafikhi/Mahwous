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
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.EntityFrameworkCore;
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
    public class VideosController : ControllerBase
    {
        private readonly string noImage = "https://www.mahwous.com/website/images/no_image.jpg";

        private readonly ApplicationDbContext context;
        private readonly IFileStorageService fileStorageService;

        public VideosController(ApplicationDbContext context,
            IFileStorageService fileStorageService)
        {
            this.context = context;
            this.fileStorageService = fileStorageService;
        }



        [AllowAnonymous]
        [HttpGet(Name = "GetVideos")]
        public async Task<ActionResult<List<VideoStatus>>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            var queryable = context.VideoStatuses.AsQueryable();
            await HttpContext.InsertPaginationParametersInResponse(queryable, paginationDTO.RecordsPerPage);
            return await queryable.Paginate(paginationDTO).ToListAsync();

        }



        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetVideo")]
        public async Task<ActionResult<VideoStatus>> Get(int id)
        {
            var video = await context.VideoStatuses
                .Include(v => v.StatusCategories).ThenInclude(sv => sv.Category)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (video == null)
            {
                return NotFound();
            }

            return video;
        }




        [HttpPost]
        public async Task<ActionResult> Post(VideoStatus video)
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
            return new CreatedAtRouteResult("GetVideo", new { id = video.Id }, video);
        }


        [HttpPut]
        public async Task<ActionResult> Put(VideoStatus video)
        {
            var oldStatus = await context.VideoStatuses.FirstOrDefaultAsync(v => v.Id == video.Id);

            if (oldStatus == null) { return NotFound(); }


            if (video is VideoStatus &&
                !string.IsNullOrWhiteSpace((video as VideoStatus).CoverPath) &&
                !(video as VideoStatus).CoverPath.Equals((oldStatus as VideoStatus).CoverPath))
            {
                var coverPath = Convert.FromBase64String((video as VideoStatus).CoverPath);
                (video as VideoStatus).CoverPath = await fileStorageService.EditFile(coverPath,
                    "jpg", "video_covers", (oldStatus as VideoStatus).CoverPath);
            }

            if (video is VideoStatus &&
                !string.IsNullOrWhiteSpace((video as VideoStatus).VideoPath) &&
                !(video as VideoStatus).VideoPath.Equals((oldStatus as VideoStatus).VideoPath))
            {
                var videoPath = Convert.FromBase64String((video as VideoStatus).VideoPath);
                (video as VideoStatus).VideoPath = await fileStorageService.EditFile(videoPath,
                    "mp4", "videos", (oldStatus as VideoStatus).VideoPath);
            }






            await context.Database.ExecuteSqlInterpolatedAsync($"delete from StatusCategories where StatusId = {video.Id}");

            oldStatus.StatusCategories = video.StatusCategories;



            context.Entry(oldStatus).CurrentValues.SetValues(video);

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var video = await context.VideoStatuses.FirstOrDefaultAsync(v => v.Id == id);
            if (video == null) { return NotFound(); }


            if (video is VideoStatus &&
                !string.IsNullOrWhiteSpace((video as VideoStatus).CoverPath))
            {
                await fileStorageService.DeleteFile((video as VideoStatus).CoverPath, "video_covers");
            }

            if (video is VideoStatus &&
                !string.IsNullOrWhiteSpace((video as VideoStatus).VideoPath))
            {
                await fileStorageService.DeleteFile((video as VideoStatus).VideoPath, "videos");
            }


            context.Remove(video);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [AllowAnonymous]
        [HttpPost("filter")]
        public async Task<ActionResult<List<VideoStatus>>> Filter(VideoFilter videoFilter)
        {

            var videosQueryable = context.VideoStatuses.AsQueryable();

            // videos title
            if (!string.IsNullOrWhiteSpace(videoFilter.Name))
            {
                videosQueryable = videosQueryable
                    .Where(v => v.Title.Contains(videoFilter.Name));
            }


            // categories filter
            if (videoFilter.WithoutCategory)
            {
                videosQueryable = videosQueryable.Where(v => v.StatusCategories == null || v.StatusCategories.Count == 0);
            }
            else if (videoFilter.Categories != null && videoFilter.Categories.Count > 0)
            {
                int[] catIds = videoFilter.Categories.Select(c => c.Id).ToArray();

                videosQueryable = videosQueryable.Where(video =>
                    video.StatusCategories.Any(sc => catIds.Contains(sc.CategoryId))
                );
            }

            // other general status properties

            videosQueryable = videosQueryable.Where(v => v.ViewsCount >= videoFilter.ViewsCount.From && v.ViewsCount <= videoFilter.ViewsCount.To);
            videosQueryable = videosQueryable.Where(v => v.DownloadsCount >= videoFilter.DownloadsCount.From && v.DownloadsCount <= videoFilter.DownloadsCount.To);
            videosQueryable = videosQueryable.Where(v => v.LikesCount >= videoFilter.LikesCount.From && v.LikesCount <= videoFilter.LikesCount.To);

            videosQueryable = videosQueryable.Where(v => v.Date >= videoFilter.Date.From && v.Date <= videoFilter.Date.To);

            videosQueryable = videosQueryable.Where(v => v.Visible == videoFilter.Visible);

            switch (videoFilter.SortType)
            {
                case SortType.Newest:
                    videosQueryable = videosQueryable.OrderByDescending(v => v.Date);
                    break;
                case SortType.Oldest:
                    videosQueryable = videosQueryable.OrderBy(v => v.Date);
                    break;
                case SortType.Views:
                    videosQueryable = videosQueryable.OrderByDescending(v => v.ViewsCount);
                    break;
                case SortType.Downloads:
                    videosQueryable = videosQueryable.OrderByDescending(v => v.DownloadsCount);
                    break;
                case SortType.Likes:
                    videosQueryable = videosQueryable.OrderByDescending(v => v.LikesCount);
                    break;
                case SortType.Random:
                    videosQueryable = videosQueryable.OrderBy(v => Guid.NewGuid());
                    break;
                default:
                    break;
            }

            await HttpContext.InsertPaginationParametersInResponse(videosQueryable,
                videoFilter.RecordsPerPage);

            var videos = await videosQueryable.Paginate(videoFilter.Pagination).ToListAsync();

            return videos;
        }

        [AllowAnonymous]
        [HttpPost("count")]
        public async Task<ActionResult<FilteredInformations>> Count(VideoFilter videoFilter)
        {

            var videosQueryable = context.VideoStatuses.AsQueryable();

            // videos title
            if (!string.IsNullOrWhiteSpace(videoFilter.Name))
            {
                videosQueryable = videosQueryable
                    .Where(v => v.Title.Contains(videoFilter.Name));
            }


            // categories filter
            if (videoFilter.WithoutCategory)
            {
                videosQueryable = videosQueryable.Where(v => v.StatusCategories == null || v.StatusCategories.Count == 0);
            }
            else if (videoFilter.Categories != null && videoFilter.Categories.Count > 0)
            {
                int[] catIds = videoFilter.Categories.Select(c => c.Id).ToArray();

                videosQueryable = videosQueryable.Where(video =>
                    video.StatusCategories.Any(sc => catIds.Contains(sc.CategoryId))
                );
            }

            // other general status properties

            videosQueryable = videosQueryable.Where(v => v.ViewsCount >= videoFilter.ViewsCount.From && v.ViewsCount <= videoFilter.ViewsCount.To);
            videosQueryable = videosQueryable.Where(v => v.DownloadsCount >= videoFilter.DownloadsCount.From && v.DownloadsCount <= videoFilter.DownloadsCount.To);
            videosQueryable = videosQueryable.Where(v => v.LikesCount >= videoFilter.LikesCount.From && v.LikesCount <= videoFilter.LikesCount.To);

            videosQueryable = videosQueryable.Where(v => v.Date >= videoFilter.Date.From && v.Date <= videoFilter.Date.To);

            videosQueryable = videosQueryable.Where(v => v.Visible == videoFilter.Visible);

            switch (videoFilter.SortType)
            {
                case SortType.Newest:
                    videosQueryable = videosQueryable.OrderByDescending(v => v.Date);
                    break;
                case SortType.Oldest:
                    videosQueryable = videosQueryable.OrderBy(v => v.Date);
                    break;
                case SortType.Views:
                    videosQueryable = videosQueryable.OrderByDescending(v => v.ViewsCount);
                    break;
                case SortType.Downloads:
                    videosQueryable = videosQueryable.OrderByDescending(v => v.DownloadsCount);
                    break;
                case SortType.Likes:
                    videosQueryable = videosQueryable.OrderByDescending(v => v.LikesCount);
                    break;
                case SortType.Random:
                    videosQueryable = videosQueryable.OrderBy(v => Guid.NewGuid());
                    break;
                default:
                    break;
            }

            FilteredInformations informations = new FilteredInformations();
            informations.StatusesCount = await videosQueryable.CountAsync();

            informations.DownloadsCount = await videosQueryable.SumAsync(s => (long)s.DownloadsCount);
            informations.LikesCount = await videosQueryable.SumAsync(s => (long)s.LikesCount);
            informations.ViewsCount = await videosQueryable.SumAsync(s => (long)s.ViewsCount);

            informations.CategoriesCount = await context.Categories.Where(c => c.ForVideos).CountAsync();

            var categoriesStatusCounts = context.Categories.Where(c => c.ForVideos).Select(c => new KeyValuePair<string, int>(c.Name, c.StatusCategories.Where(sc => sc.Status is VideoStatus).Count()));
            informations.CategoriesStatusCounts = new Dictionary<string, int>(categoriesStatusCounts);

            return informations;
        }



        [AllowAnonymous]
        [HttpGet("count")]
        public async Task<ActionResult<FilteredInformations>> Count()
        {
            FilteredInformations informations = new FilteredInformations();
            informations.StatusesCount = await context.VideoStatuses.CountAsync();

            informations.DownloadsCount = await context.VideoStatuses.SumAsync(s => (long)s.DownloadsCount);
            informations.LikesCount = await context.VideoStatuses.SumAsync(s => (long)s.LikesCount);
            informations.ViewsCount = await context.VideoStatuses.SumAsync(s => (long)s.ViewsCount);

            informations.CategoriesCount = await context.Categories.Where(c => c.ForVideos).CountAsync();

            var categoriesStatusCounts = context.Categories.Where(c => c.ForVideos).Select(c => new KeyValuePair<string, int>(c.Name, c.StatusCategories.Where(sc => sc.Status is VideoStatus).Count()));
            informations.CategoriesStatusCounts = new Dictionary<string, int>(categoriesStatusCounts);

            return informations;
        }
    }
}
