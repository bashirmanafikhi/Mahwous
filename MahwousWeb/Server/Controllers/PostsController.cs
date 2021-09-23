using MahwousWeb.Persistent;
using MahwousWeb.API.Controllers.MyControllerBase;
using MahwousWeb.API.Helpers;
using MahwousWeb.Models.Filters;
using MahwousWeb.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace MahwousWeb.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : GenericControllerBase<Post, PostFilter>
    {
        public PostsController(ApplicationDbContext context, IFileStorageService fileStorageService)
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
            var oldPost = await context.Posts.FirstOrDefaultAsync(c => c.Id == post.Id);

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
            var post = await context.Posts.FirstOrDefaultAsync(c => c.Id == id);

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
