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
    public class CategoriesController : ControllerBase
    {
        private readonly string noImage = "https://www.mahwous.com/website/images/no_image.jpg";

        private readonly ApplicationDbContext context;
        private readonly IFileStorageService fileStorageService;

        public CategoriesController(ApplicationDbContext context,
            IFileStorageService fileStorageService)
        {
            this.context = context;
            this.fileStorageService = fileStorageService;
        }

        [AllowAnonymous]
        [HttpGet(Name ="GetCategories")]
        public async Task<ActionResult<List<Category>>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            var queryable = context.Categories.AsQueryable();
            await HttpContext.InsertPaginationParametersInResponse(queryable, paginationDTO.RecordsPerPage);
            return await queryable.Paginate(paginationDTO).ToListAsync();
            
        }


        [AllowAnonymous]
        [HttpGet("{id}", Name ="GetCategory")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            return await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Category category)
        {
            if (!string.IsNullOrWhiteSpace(category.CoverPath))
            {
                var categoryCover = Convert.FromBase64String(category.CoverPath);
                category.CoverPath = await fileStorageService.SaveFile(categoryCover, "jpg", "categories");
            }
            else
            {
                category.CoverPath = noImage;
            }

            context.Add(category);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetCategory", new { id = category.Id }, category);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Category category)
        {
            var oldCategory = await context.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);

            if (oldCategory == null) { return NotFound(); }


            if (!string.IsNullOrWhiteSpace(category.CoverPath) &&
                !category.CoverPath.Equals(oldCategory.CoverPath))
            {
                var categoryCover = Convert.FromBase64String(category.CoverPath);
                category.CoverPath = await fileStorageService.EditFile(categoryCover,
                    "jpg", "categories", oldCategory.CoverPath);
            }

            context.Entry(oldCategory).CurrentValues.SetValues(category);

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) { return NotFound(); }


            if (!string.IsNullOrWhiteSpace(category.CoverPath))
            {
                await fileStorageService.DeleteFile(category.CoverPath , "categories");
            }


            //var category = new Category { Id = id };
            context.Remove(category);
            await context.SaveChangesAsync();
            return NoContent();
        }




        [AllowAnonymous]
        [HttpPost("filter")]
        public async Task<ActionResult<List<Category>>> Filter(CategoryFilter categoryFilter)
        {

            var categoriesQueryable = context.Categories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(categoryFilter.Name))
            {
                categoriesQueryable = categoriesQueryable
                    .Where(c => c.Name.Contains(categoryFilter.Name));
            }

            if (categoryFilter.ForImages)
            {
                categoriesQueryable = categoriesQueryable.Where(c => c.ForImages);
            }

            if (categoryFilter.ForQuotes)
            {
                categoriesQueryable = categoriesQueryable.Where(c => c.ForQuotes);
            }

            if (categoryFilter.ForVideos)
            {
                categoriesQueryable = categoriesQueryable.Where(c => c.ForVideos);
            }

            categoriesQueryable = categoriesQueryable.OrderByDescending(c => c.Id);

            await HttpContext.InsertPaginationParametersInResponse(categoriesQueryable,
                categoryFilter.RecordsPerPage);

            var categories = await categoriesQueryable.Paginate(categoryFilter.Pagination).ToListAsync();

            return categories;
        }
    }
}
