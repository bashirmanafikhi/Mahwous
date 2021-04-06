using MahwousWeb.Persistent;
using MahwousWeb.Server.Controllers.MyControllerBase;
using MahwousWeb.Server.Helpers;
using MahwousWeb.Models.Filters;
using MahwousWeb.Models.Models;
using MahwousWeb.Models.Pagination;
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


    }
}
