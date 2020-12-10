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
using System.Linq;
using System.Threading.Tasks;

namespace MahwousWeb.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : GenericControllerBase<Post, PostFilter>
    {
        public PostsController(ApplicationDbContext context, IFileStorageService fileStorageService)
            : base(context, fileStorageService) { }


        //[HttpPost]
        //[Authorize]
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

        //[HttpPut]
        //[Authorize]
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

        //[HttpDelete("{id}")]
        //[Authorize]
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


        //[HttpGet("GetInformations")]
        //public override async Task<ActionResult<Informations>> GetInformations()
        //{
        //    return await GetPostsInformations();
        //}


        //[HttpPost("GetInformationsFiltered")]
        //public async Task<ActionResult<Informations>> GetInformations(PostFilter filter)
        //{ return await GetInformations((IFilter<Post>)filter); }
        //[NonAction]
        //public override async Task<ActionResult<Informations>> GetInformations(IFilter<Post> filter)
        //{
        //    return await GetPostsInformations(filter);
        //}

        //private async Task<Informations> GetPostsInformations(IFilter<Post> filter = null)
        //{
        //    var posts = context.Posts.Filter(filter);

        //    Informations informations = new Informations();
        //    informations.Count = await posts.CountAsync();
        //    informations.ViewsCount = await posts.SumAsync(s => (long)s.ViewsCount);

        //    return informations;
        //}
    }
}
