using MahwousWeb.Persistent;
using MahwousWeb.Server.Controllers.MyControllerBase;
using MahwousWeb.Server.Helpers;
using MahwousWeb.Models.Filters;
using MahwousWeb.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MahwousWeb.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : GenericControllerBase<Post, PostFilter>
    {
        public PostsController(ApplicationDbContext context, IFileStorageService fileStorageService)
            : base(context, fileStorageService) { }


        public override async Task<ActionResult<int>> Post(Post post)
        {
            if (!string.IsNullOrWhiteSpace(post.ImagePath))
            {
                var postCover = Convert.FromBase64String(post.ImagePath);
                post.ImagePath = await fileStorageService.SaveFile(postCover, "jpg", "posts");
            }
            else
            {
                post.ImagePath = noImage;
            }

            context.Add(post);
            await context.SaveChangesAsync();
            return post.Id;
        }


        public override async Task<IActionResult> Put(Post post)
        {
            var oldPost = await context.Posts.FirstOrDefaultAsync(c => c.Id == post.Id);

            if (oldPost == null) { return NotFound(); }


            if (!string.IsNullOrWhiteSpace(post.ImagePath) &&
                !post.ImagePath.Equals(oldPost.ImagePath))
            {
                var postCover = Convert.FromBase64String(post.ImagePath);
                post.ImagePath = await fileStorageService.EditFile(postCover,
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
