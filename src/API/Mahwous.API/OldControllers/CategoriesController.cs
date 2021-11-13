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
//using Mahwous.Application.Extensions;

//namespace Mahwous.API.Controllers
//{

//    [ApiController]
//    [Route("api/[controller]")]
//    public class CategoriesController : GenericControllerBase<Category, CategoryFilter>
//    {
//        public CategoriesController(ApplicationDbContext context, IFileStorageService fileStorageService)
//            : base(context, fileStorageService) { }


//        [Authorize]
//        [HttpPost]
//        public async Task<ActionResult<int>> Post([FromForm] string serializedObject, [FromForm] IFormFile coverFile)
//        {
//            Category category = JsonSerializer.Deserialize<Category>(serializedObject);

//            if (coverFile != null && coverFile.Length > 0)
//                category.CoverPath = await fileStorageService.SaveFile(coverFile.ToMemoryStream(), Core.Enums.FileType.Image);
//            else
//                category.CoverPath = noImage;

//            context.Add(category);
//            await context.SaveChangesAsync();
//            return category.Id;
//        }

//        [Authorize]
//        [HttpPut]
//        public async Task<ActionResult<int>> Put([FromForm] string serializedObject, [FromForm] IFormFile coverFile)
//        {
//            Category category = JsonSerializer.Deserialize<Category>(serializedObject);
//            var oldCategory = await context.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);

//            if (oldCategory == null) { return NotFound(); }

//            if (coverFile != null && coverFile.Length > 0)
//            {
//                category.CoverPath = await fileStorageService.EditFile(oldCategory.CoverPath, coverFile.ToMemoryStream(), Core.Enums.FileType.Image);
//            }

//            context.Entry(oldCategory).CurrentValues.SetValues(category);

//            await context.SaveChangesAsync();
//            return NoContent();
//        }


//        public override async Task<IActionResult> Delete(int id)
//        {
//            var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);

//            if (category == null) { return NotFound(); }


//            if (!string.IsNullOrWhiteSpace(category.CoverPath))
//            {
//                await fileStorageService.DeleteFile(category.CoverPath);
//            }

//            context.Remove(category);
//            await context.SaveChangesAsync();
//            return NoContent();
//        }


//    }
//}
