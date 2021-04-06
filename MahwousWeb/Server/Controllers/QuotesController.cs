using MahwousWeb.Persistent;
using MahwousWeb.Server.Controllers.MyControllerBase;
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
using System.Text;
using System.Threading.Tasks;

namespace MahwousWeb.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuotesController : GenericStatusesControllerBase<QuoteStatus, QuoteFilter>
    {
        public QuotesController(ApplicationDbContext context, IFileStorageService fileStorageService)
            : base(context, fileStorageService) { }


        //[HttpPost]
        //[Authorize]
        public override async Task<ActionResult<int>> Post(QuoteStatus quote)
        {
            context.Add(quote);
            await context.SaveChangesAsync();
            return quote.Id;
        }

        //[HttpPut]
        //[Authorize]
        
        public override async Task<IActionResult> Put(QuoteStatus quote)
        {
            var oldQuote = await context.QuoteStatuses.FirstOrDefaultAsync(c => c.Id == quote.Id);

            if (oldQuote == null) { return NotFound(); }



            await context.Database.ExecuteSqlInterpolatedAsync($"delete from StatusCategories where StatusId = {quote.Id}");

            oldQuote.StatusCategories = quote.StatusCategories;

            context.Entry(oldQuote).CurrentValues.SetValues(quote);

            await context.SaveChangesAsync();
            return NoContent();
        }

        //[HttpDelete("{id}")]
        //[Authorize]
        public override async Task<IActionResult> Delete(int id)
        {
            var quote = await context.QuoteStatuses.FirstOrDefaultAsync(c => c.Id == id);

            if (quote == null) { return NotFound(); }


            context.Remove(quote);
            await context.SaveChangesAsync();
            return NoContent();
        }

        //[HttpGet("GetInformations")]
        //public override async Task<ActionResult<Informations>> GetInformations()
        //{
        //    return await GetQuotesInformations();
        //}


        //[HttpPost("GetInformationsFiltered")]
        //public override async Task<ActionResult<Informations>> GetInformations(QuoteFilter filter)
        //{ 
        //    return await GetQuotesInformations(filter); 
        //}

        ////[NonAction]
        ////public override async Task<ActionResult<Informations>> GetInformations(IFilter<QuoteStatus> filter)
        ////{
        ////    return await GetQuotesInformations(filter);
        ////}

        //private async Task<Informations> GetQuotesInformations(IFilter<QuoteStatus> filter = null)
        //{
        //    var quotes = context.QuoteStatuses.Filter(filter);

        //    Informations informations = new Informations
        //    {
        //        Count = await quotes.CountAsync(),
        //        DownloadsCount = await quotes.SumAsync(s => (long)s.DownloadsCount),
        //        LikesCount = await quotes.SumAsync(s => (long)s.LikesCount),
        //        ViewsCount = await quotes.SumAsync(s => (long)s.ViewsCount)
        //    };


        //    var categoriesStatusCounts = context.Categories.Where(c => c.ForQuotes).Select(c => new KeyValuePair<string, int>(c.Name, c.StatusCategories.Where(sc => sc.Status is QuoteStatus).Count()));
        //    informations.CategoriesStatusCounts = new Dictionary<string, int>(categoriesStatusCounts);

        //    return informations;
        //}


        [HttpGet("Download/{id}")]
        public async Task<IActionResult> Download(int id)
        {
            var quote = await context.QuoteStatuses.FirstOrDefaultAsync(c => c.Id == id);

            if (quote == null) { return NotFound(); }

            byte[] byteArray = Encoding.UTF8.GetBytes(quote.Content);

            return File(byteArray, "application/octet-stream", "Mahwous Quote " + quote.Id + ".txt");
        }
    }
}
