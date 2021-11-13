//using Mahwous.Core.Entities;
//using Mahwous.Core.Filters;
//using Mahwous.API.Controllers.MyControllerBase;
//using Mahwous.Persistence;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Text.Json;
//using System.Threading.Tasks;
//using Mahwous.Core.Interfaces;

//namespace Mahwous.API.Controllers
//{

//    [ApiController]
//    [Route("api/[controller]")]
//    public class VideosController : GenericStatusesControllerBase<VideoStatus, VideoFilter>
//    {
//        public VideosController(ApplicationDbContext context, IFileStorageService fileStorageService)
//            : base(context, fileStorageService) { }


//        //[Authorize]
//        //[HttpPost]
//        //public async Task<ActionResult<int>> Post([FromForm] string serializedObject, [FromForm] IFormFile coverFile, [FromForm] IFormFile videoFile)
//        //{
//        //    VideoStatus video = JsonSerializer.Deserialize<VideoStatus>(serializedObject);

//        //    if (coverFile != null && coverFile.Length > 0)
//        //        video.CoverPath = await fileStorageService.SaveFile(coverFile, "jpg", "video_covers");
//        //    else
//        //        video.CoverPath = noImage;

//        //    if (videoFile.Length > 0)
//        //        video.VideoPath = await fileStorageService.SaveFile(videoFile, "mp4", "videos");

//        //    context.Add(video);
//        //    await context.SaveChangesAsync();
//        //    return Ok(video.Id);
//        //}

//        //[Authorize]
//        //[HttpPut]
//        //public async Task<IActionResult> Put([FromForm] string serializedObject, [FromForm] IFormFile coverFile, [FromForm] IFormFile videoFile)
//        //{
//        //    VideoStatus video = JsonSerializer.Deserialize<VideoStatus>(serializedObject);

//        //    var oldStatus = await context.VideoStatuses.FirstOrDefaultAsync(c => c.Id == video.Id);

//        //    if (oldStatus == null) { return NotFound(); }

//        //    if (coverFile != null && coverFile.Length > 0)
//        //        video.CoverPath = await fileStorageService.SaveFile(coverFile, "jpg", "video_covers");

//        //    if (videoFile != null && videoFile.Length > 0)
//        //        video.VideoPath = await fileStorageService.SaveFile(videoFile, "mp4", "videos");

//        //    await context.Database.ExecuteSqlInterpolatedAsync($"delete from StatusCategories where StatusId = {video.Id}");

//        //    oldStatus.Categories = video.Categories;

//        //    context.Entry(oldStatus).CurrentValues.SetValues(video);

//        //    await context.SaveChangesAsync();
//        //    return NoContent();
//        //}


//        public override async Task<IActionResult> Delete(int id)
//        {
//            var video = await context.VideoStatuses.FirstOrDefaultAsync(c => c.Id == id);

//            if (video == null) { return NotFound(); }


//            if (!string.IsNullOrWhiteSpace(video.CoverPath))
//            {
//                await fileStorageService.DeleteFile(video.CoverPath);
//            }

//            if (!string.IsNullOrWhiteSpace(video.VideoPath))
//            {
//                await fileStorageService.DeleteFile(video.VideoPath);
//            }

//            context.Remove(video);
//            await context.SaveChangesAsync();
//            return NoContent();
//        }


//        [HttpGet("Download/{id}")]
//        public async Task<IActionResult> Download(int id)
//        {
//            var video = await context.VideoStatuses.FirstOrDefaultAsync(c => c.Id == id);

//            if (video == null) { return NotFound(); }

//            byte[] file = fileStorageService.GetFile(video.VideoPath);

//            return File(file, "application/octet-stream", "Mahwous Video " + video.Id + ".mp4");
//        }
//    }
//}
