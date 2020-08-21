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
    public class StatusesController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        private readonly IFileStorageService fileStorageService;

        public StatusesController(ApplicationDbContext context,
            IFileStorageService fileStorageService)
        {
            this.context = context;
            this.fileStorageService = fileStorageService;
        }



        [AllowAnonymous]
        [HttpGet(Name = "GetStatuses")]
        public async Task<ActionResult<List<Status>>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            var queryable = context.Statuses.AsQueryable();
            await HttpContext.InsertPaginationParametersInResponse(queryable, paginationDTO.RecordsPerPage);
            return await queryable.Paginate(paginationDTO).ToListAsync();

        }



        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetStatus")]
        public async Task<ActionResult<Status>> Get(int id)
        {
            return await context.Statuses.FirstOrDefaultAsync(s => s.Id == id);
        }




        [HttpPost]
        public async Task<ActionResult> Post(Status status)
        {
            if (status is ImageStatus &&
                !string.IsNullOrWhiteSpace((status as ImageStatus).ImagePath))
            {
                var imagePath = Convert.FromBase64String((status as ImageStatus).ImagePath);
                (status as ImageStatus).ImagePath = await fileStorageService.SaveFile(imagePath, "jpg", "images");
            }

            if (status is VideoStatus &&
                !string.IsNullOrWhiteSpace((status as VideoStatus).CoverPath))
            {
                var coverPath = Convert.FromBase64String((status as VideoStatus).CoverPath);
                (status as VideoStatus).CoverPath = await fileStorageService.SaveFile(coverPath, "jpg", "video_covers");
            }

            if (status is VideoStatus &&
                !string.IsNullOrWhiteSpace((status as VideoStatus).VideoPath))
            {
                var videoPath = Convert.FromBase64String((status as VideoStatus).VideoPath);
                (status as VideoStatus).VideoPath = await fileStorageService.SaveFile(videoPath, "mp4", "videos");
            }



            context.Add(status);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetStatus", new { id = status.Id }, status);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Status status)
        {
            var oldStatus = await context.Statuses.FirstOrDefaultAsync(s => s.Id == status.Id);

            if (oldStatus == null) { return NotFound(); }


            if (status is ImageStatus &&
                !string.IsNullOrWhiteSpace((status as ImageStatus).ImagePath) &&
                !(status as ImageStatus).ImagePath.Equals((oldStatus as ImageStatus).ImagePath))
            {
                var imagePath = Convert.FromBase64String((status as ImageStatus).ImagePath);
                (status as ImageStatus).ImagePath = await fileStorageService.EditFile(imagePath,
                    "jpg", "images", (oldStatus as ImageStatus).ImagePath);
            }




            if (status is VideoStatus &&
                !string.IsNullOrWhiteSpace((status as VideoStatus).CoverPath) &&
                !(status as VideoStatus).CoverPath.Equals((oldStatus as VideoStatus).CoverPath))
            {
                var coverPath = Convert.FromBase64String((status as VideoStatus).CoverPath);
                (status as VideoStatus).CoverPath = await fileStorageService.EditFile(coverPath,
                    "jpg", "video_covers", (oldStatus as VideoStatus).CoverPath);
            }

            if (status is VideoStatus &&
                !string.IsNullOrWhiteSpace((status as VideoStatus).VideoPath) &&
                !(status as VideoStatus).VideoPath.Equals((oldStatus as VideoStatus).VideoPath))
            {
                var videoPath = Convert.FromBase64String((status as VideoStatus).VideoPath);
                (status as VideoStatus).VideoPath = await fileStorageService.EditFile(videoPath,
                    "mp4", "videos", (oldStatus as VideoStatus).VideoPath);
            }






            context.Entry(oldStatus).CurrentValues.SetValues(status);

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var status = await context.Statuses.FirstOrDefaultAsync(s => s.Id == id);
            if (status == null) { return NotFound(); }

            if (status is ImageStatus &&
                !string.IsNullOrWhiteSpace((status as ImageStatus).ImagePath))
            {
                await fileStorageService.DeleteFile((status as ImageStatus).ImagePath, "images");
            }

            if (status is VideoStatus &&
                !string.IsNullOrWhiteSpace((status as VideoStatus).CoverPath))
            {
                await fileStorageService.DeleteFile((status as VideoStatus).CoverPath, "video_covers");
            }

            if (status is VideoStatus &&
                !string.IsNullOrWhiteSpace((status as VideoStatus).VideoPath))
            {
                await fileStorageService.DeleteFile((status as VideoStatus).VideoPath, "videos");
            }


            context.Remove(status);
            await context.SaveChangesAsync();
            return NoContent();
        }


        [AllowAnonymous]
        [HttpPost("filter")]
        public async Task<ActionResult<List<Status>>> Filter(StatusFilter statusFilter)
        {

            var statusesQueryable = context.Statuses.AsQueryable();



            // categories filter
            if (statusFilter.Categories != null && statusFilter.Categories.Count > 0)
            {
                int[] catIds = statusFilter.Categories.Select(c => c.Id).ToArray();

                statusesQueryable = statusesQueryable.Where(status =>
                    status.StatusCategories.Any(sc => catIds.Contains(sc.CategoryId))
                );
            }

            // other general status properties

            statusesQueryable = statusesQueryable.Where(v => v.ViewsCount >= statusFilter.ViewsCount);
            statusesQueryable = statusesQueryable.Where(v => v.DownloadsCount >= statusFilter.DownloadsCount);
            statusesQueryable = statusesQueryable.Where(v => v.LikesCount >= statusFilter.LikesCount);

            if (statusFilter.Visible)
            {
                statusesQueryable = statusesQueryable.Where(v => v.Visible);
            }

            if (statusFilter.DateFrom != DateTime.MinValue)
                statusesQueryable = statusesQueryable.Where(v => v.Date > statusFilter.DateFrom);
            if (statusFilter.DateTo != DateTime.MinValue)
                statusesQueryable = statusesQueryable.Where(v => v.Date < statusFilter.DateTo);

            switch (statusFilter.SortType)
            {
                case SortType.Newest:
                    statusesQueryable = statusesQueryable.OrderByDescending(v => v.Date);
                    break;
                case SortType.Oldest:
                    statusesQueryable = statusesQueryable.OrderBy(v => v.Date);
                    break;
                case SortType.Views:
                    statusesQueryable = statusesQueryable.OrderByDescending(v => v.ViewsCount);
                    break;
                case SortType.Downloads:
                    statusesQueryable = statusesQueryable.OrderByDescending(v => v.DownloadsCount);
                    break;
                case SortType.Random:
                    statusesQueryable = statusesQueryable.OrderBy(v => Guid.NewGuid());
                    break;
                default:
                    break;
            }

            await HttpContext.InsertPaginationParametersInResponse(statusesQueryable,
                statusFilter.RecordsPerPage);

            var statuses = await statusesQueryable.Paginate(statusFilter.Pagination).ToListAsync();

            return statuses;
        }




        [AllowAnonymous]
        [HttpPost("incrementviews/{id}")]
        public async Task<ActionResult> IncrementViews(int id)
        {
            var status = await context.Statuses.FirstOrDefaultAsync(s => s.Id == id);

            if (status == null) { return NotFound(); }

            status.ViewsCount++;

            await context.SaveChangesAsync();
            //return NoContent();
            return Ok();
        }



        [AllowAnonymous]
        [HttpPost("incrementdownloads/{id}")]
        public async Task<ActionResult> IncrementDownloads(int id)
        {
            var status = await context.Statuses.FirstOrDefaultAsync(s => s.Id == id);

            if (status == null) { return NotFound(); }

            status.DownloadsCount++;

            await context.SaveChangesAsync();
            return Ok();
        }



        [AllowAnonymous]
        [HttpPost("incrementlikes/{id}")]
        public async Task<ActionResult> IncrementLikes(int id)
        {
            var status = await context.Statuses.FirstOrDefaultAsync(s => s.Id == id);

            if (status == null) { return NotFound(); }

            status.LikesCount++;

            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
