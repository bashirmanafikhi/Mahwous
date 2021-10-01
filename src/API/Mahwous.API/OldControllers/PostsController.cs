using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.API.Controllers.MyControllerBase;
using Mahwous.API.Helpers;
using MahwousWeb.Persistent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mahwous.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OldPostsController : GenericControllerBase<Post, PostFilter>
    {
        public OldPostsController(ApplicationDbContext context, IFileStorageService fileStorageService)
            : base(context, fileStorageService) { }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromForm] string serializedObject, [FromForm] IFormFile coverFile)
        {
            Post post = JsonSerializer.Deserialize<Post>(serializedObject);

            if (coverFile != null && coverFile.Length > 0)
            {
                post.ImagePath = await fileStorageService.SaveFile(coverFile, "jpg", "posts");
            }
            else
            {
                post.ImagePath = noImage;
            }

            context.Add(post);
            await context.SaveChangesAsync();
            return post.Id;
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<int>> Put([FromForm] string serializedObject, [FromForm] IFormFile coverFile)
        {
            Post post = JsonSerializer.Deserialize<Post>(serializedObject);
            var oldPost = await context.Posts.FirstOrDefaultAsync(/*c => c.Id == post.Id*/);

            if (oldPost == null) { return NotFound(); }

            if (coverFile != null && coverFile.Length > 0)
            {
                post.ImagePath = await fileStorageService.EditFile(coverFile,
                    "jpg", oldPost.ImagePath);
            }

            context.Entry(oldPost).CurrentValues.SetValues(post);

            await context.SaveChangesAsync();
            return NoContent();
        }


        public override async Task<IActionResult> Delete(int id)
        {
            var post = await context.Posts.FirstOrDefaultAsync(/* c => c.Id == id */);

            if (post == null) { return NotFound(); }

            if (!string.IsNullOrWhiteSpace(post.ImagePath))
            {
                await fileStorageService.DeleteFile(post.ImagePath);
            }

            context.Remove(post);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
