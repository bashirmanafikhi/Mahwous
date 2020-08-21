using AutoMapper;
using MahwousWeb.Server.Data;
using MahwousWeb.Server.Helpers;
using MahwousWeb.Shared;
using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahwousWeb.Server.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly string noImage = "https://www.mahwous.com/website/images/no_image.jpg";

        private readonly ApplicationDbContext context;
        private readonly IFileStorageService fileStorageService;

        public PostsController(ApplicationDbContext context,
            IFileStorageService fileStorageService)
        {
            this.context = context;
            this.fileStorageService = fileStorageService;
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetPosts")]
        public async Task<ActionResult<List<Post>>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            var queryable = context.Posts.AsQueryable();
            await HttpContext.InsertPaginationParametersInResponse(queryable, paginationDTO.RecordsPerPage);
            return await queryable.Paginate(paginationDTO).ToListAsync();

        }


        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetPost")]
        public async Task<ActionResult<Post>> Get(int id)
        {
            return await context.Posts.FirstOrDefaultAsync(c => c.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Post post)
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
            return new CreatedAtRouteResult("GetPost", new { id = post.Id }, post);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Post post)
        {
            var oldPost = await context.Posts.FirstOrDefaultAsync(c => c.Id == post.Id);

            if (oldPost == null) { return NotFound(); }


            if (!string.IsNullOrWhiteSpace(post.ImagePath) &&
                !post.ImagePath.Equals(oldPost.ImagePath))
            {
                var postCover = Convert.FromBase64String(post.ImagePath);
                post.ImagePath = await fileStorageService.EditFile(postCover,
                    "jpg", "posts", oldPost.ImagePath);
            }

            context.Entry(oldPost).CurrentValues.SetValues(post);

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var post = await context.Posts.FirstOrDefaultAsync(c => c.Id == id);

            if (post == null) { return NotFound(); }


            if (!string.IsNullOrWhiteSpace(post.ImagePath))
            {
                await fileStorageService.DeleteFile(post.ImagePath, "posts");
            }

            context.Remove(post);
            await context.SaveChangesAsync();
            return NoContent();
        }


    }
}
