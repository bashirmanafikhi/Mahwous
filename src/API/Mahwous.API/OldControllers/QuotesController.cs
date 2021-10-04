//using Mahwous.Core.Entities;
//using Mahwous.Core.Filters;
//using Mahwous.API.Controllers.MyControllerBase;
//using MahwousWeb.Persistent;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Text;
//using System.Threading.Tasks;
//using Mahwous.Core.Interfaces;

//namespace Mahwous.API.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class QuotesController : GenericStatusesControllerBase<QuoteStatus, QuoteFilter>
//    {
//        public QuotesController(ApplicationDbContext context, IFileStorageService fileStorageService)
//            : base(context, fileStorageService) { }


//        [Authorize]
//        [HttpPost]
//        public async Task<ActionResult<int>> Post(QuoteStatus quote)
//        {
//            context.Add(quote);
//            await context.SaveChangesAsync();
//            return quote.Id;
//        }



//        [Authorize]
//        [HttpPut]
//        public async Task<IActionResult> Put(QuoteStatus quote)
//        {
//            var oldQuote = await context.QuoteStatuses.FirstOrDefaultAsync(c => c.Id == quote.Id);

//            if (oldQuote == null) { return NotFound(); }

//            await context.Database.ExecuteSqlInterpolatedAsync($"delete from StatusCategories where StatusId = {quote.Id}");

//            oldQuote.Categories = quote.Categories;

//            context.Entry(oldQuote).CurrentValues.SetValues(quote);

//            await context.SaveChangesAsync();
//            return NoContent();
//        }


//        public override async Task<IActionResult> Delete(int id)
//        {
//            var quote = await context.QuoteStatuses.FirstOrDefaultAsync(c => c.Id == id);

//            if (quote == null) { return NotFound(); }


//            context.Remove(quote);
//            await context.SaveChangesAsync();
//            return NoContent();
//        }


//        [HttpGet("Download/{id}")]
//        public async Task<IActionResult> Download(int id)
//        {
//            var quote = await context.QuoteStatuses.FirstOrDefaultAsync(c => c.Id == id);

//            if (quote == null) { return NotFound(); }

//            byte[] byteArray = Encoding.UTF8.GetBytes(quote.Content);

//            return File(byteArray, "application/octet-stream", "Mahwous Quote " + quote.Id + ".txt");
//        }
//    }
//}
