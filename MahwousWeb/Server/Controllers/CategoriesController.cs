using Mahwous.Core.Models;
using MahwousWeb.API.Controllers.MyControllerBase;
using MahwousWeb.API.Helpers;
using MahwousWeb.Models.Filters;
using MahwousWeb.Persistent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Threading.Tasks;

namespace MahwousWeb.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : GenericControllerBase<Category, CategoryFilter>
    {
        public CategoriesController(ApplicationDbContext context, IFileStorageService fileStorageService)
            : base(context, fileStorageService) { }


        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromForm] string serializedObject, [FromForm] IFormFile coverFile)
        {
            Category category = JsonSerializer.Deserialize<Category>(serializedObject);

            if (coverFile != null && coverFile.Length > 0)
                category.CoverPath = await fileStorageService.SaveFile(coverFile, "jpg", "categories");
            else
                category.CoverPath = noImage;

            context.Add(category);
            await context.SaveChangesAsync();
            return category.Id;
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<int>> Put([FromForm] string serializedObject, [FromForm] IFormFile coverFile)
        {
            Category category = JsonSerializer.Deserialize<Category>(serializedObject);
            var oldCategory = await context.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);

            if (oldCategory == null) { return NotFound(); }

            if (coverFile != null && coverFile.Length > 0)
            {
                category.CoverPath = await fileStorageService.EditFile(coverFile,
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
