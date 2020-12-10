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
    public class CategoriesController : GenericControllerBase<Category, CategoryFilter>
    {
        public CategoriesController(ApplicationDbContext context, IFileStorageService fileStorageService)
            : base(context, fileStorageService) { }


        //[HttpPost]
        //[Authorize]
        public override async Task<ActionResult<int>> Post(Category category)
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
            return category.Id;
        }

        //[HttpPut]
        //[Authorize]
        public override async Task<IActionResult> Put(Category category)
        {
            var oldCategory = await context.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);

            if (oldCategory == null) { return NotFound(); }


            if (!string.IsNullOrWhiteSpace(category.CoverPath) &&
                !category.CoverPath.Equals(oldCategory.CoverPath))
            {
                var categoryCover = Convert.FromBase64String(category.CoverPath);
                category.CoverPath = await fileStorageService.EditFile(categoryCover,
                    "jpg", oldCategory.CoverPath);
            }

            context.Entry(oldCategory).CurrentValues.SetValues(category);

            await context.SaveChangesAsync();
            return NoContent();
        }

        //[HttpDelete("{id}")]
        //[Authorize]
        public override async Task<IActionResult> Delete(int id)
        {
            var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) { return NotFound(); }


            if (!string.IsNullOrWhiteSpace(category.CoverPath))
            {
                await fileStorageService.DeleteFile(category.CoverPath);
            }

            context.Remove(category);
            await context.SaveChangesAsync();
            return NoContent();
        }

        
        //[HttpGet("GetInformations")]
        //public override async Task<ActionResult<Informations>> GetInformations()
        //{
        //    return await GetCategoriesInformations();
        //}


        //[HttpPost("GetInformationsFiltered")]
        //public async Task<ActionResult<Informations>> GetInformations(CategoryFilter filter)
        //{ return await GetInformations((IFilter<Category>)filter); }
        //[NonAction]
        //public override async Task<ActionResult<Informations>> GetInformations(IFilter<Category> filter)
        //{
        //    return await GetCategoriesInformations(filter);
        //}

        //private async Task<Informations> GetCategoriesInformations(IFilter<Category> filter = null)
        //{
        //    var categories = context.Categories.Filter(filter);

        //    Informations informations = new Informations
        //    {
        //        Count = await categories.CountAsync(),
        //        ViewsCount = await categories.SumAsync(s => (long)s.ViewsCount)
        //    };

        //    return informations;
        //}


    }
}
