using AutoMapper;
using MahwousWeb.Server.Data;
using MahwousWeb.Server.Helpers;
using MahwousWeb.Shared;
using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MahwousWeb.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class QuotesController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        private readonly IFileStorageService fileStorageService;

        public QuotesController(ApplicationDbContext context,
            IFileStorageService fileStorageService)
        {
            this.context = context;
            this.fileStorageService = fileStorageService;
        }



        [AllowAnonymous]
        [HttpGet(Name = "GetQuotes")]
        public async Task<ActionResult<List<QuoteStatus>>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            var queryable = context.QuoteStatuses.AsQueryable();

            
            
            await HttpContext.InsertPaginationParametersInResponse(queryable, paginationDTO.RecordsPerPage);
            return await queryable.Paginate(paginationDTO).ToListAsync();

        }



        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetQuote")]
        public async Task<ActionResult<QuoteStatus>> Get(int id)
        {
            var quote = await context.QuoteStatuses
                .Include(q => q.StatusCategories).ThenInclude(sc => sc.Category)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (quote == null)
            {
                return NotFound();
            }

            return quote;
        }




        [HttpPost]
        public async Task<ActionResult> Post(QuoteStatus quoteStatus)
        {

            context.Add(quoteStatus);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetQuote", new { id = quoteStatus.Id }, quoteStatus);
        }


        [HttpPut]
        public async Task<ActionResult> Put(QuoteStatus quote)
        {
            var oldQuote = await context.QuoteStatuses.FirstOrDefaultAsync(q => q.Id == quote.Id);

            if (oldQuote == null) { return NotFound(); }



            await context.Database.ExecuteSqlInterpolatedAsync($"delete from StatusCategories where StatusId = {quote.Id}");

            oldQuote.StatusCategories = quote.StatusCategories;



            context.Entry(oldQuote).CurrentValues.SetValues(quote);

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var quote = await context.QuoteStatuses.FirstOrDefaultAsync(q => q.Id == id);
            if (quote == null) { return NotFound(); }

            


            context.Remove(quote);
            await context.SaveChangesAsync();
            return NoContent();
        }


        [AllowAnonymous]
        [HttpPost("filter")]
        public async Task<ActionResult<List<QuoteStatus>>> Filter(QuoteFilter quoteFilter)
        {

            var quotesQueryable = context.QuoteStatuses.AsQueryable();

            // videos title
            if (!string.IsNullOrWhiteSpace(quoteFilter.Content))
            {
                quotesQueryable = quotesQueryable
                    .Where(v => v.Content.Contains(quoteFilter.Content));
            }


            // categories filter
            if (quoteFilter.Categories != null && quoteFilter.Categories.Count > 0)
            {
                int[] catIds = quoteFilter.Categories.Select(c => c.Id).ToArray();

                quotesQueryable = quotesQueryable.Where(quote =>
                    quote.StatusCategories.Any(sc => catIds.Contains(sc.CategoryId))
                );
            }

            // other general status properties

            quotesQueryable = quotesQueryable.Where(v => v.ViewsCount >= quoteFilter.ViewsCount);
            quotesQueryable = quotesQueryable.Where(v => v.DownloadsCount >= quoteFilter.DownloadsCount);
            quotesQueryable = quotesQueryable.Where(v => v.LikesCount >= quoteFilter.LikesCount);


            if (quoteFilter.Visible)
            {
                quotesQueryable = quotesQueryable.Where(v => v.Visible);
            }

            if (quoteFilter.DateFrom != DateTime.MinValue)
                quotesQueryable = quotesQueryable.Where(v => v.Date > quoteFilter.DateFrom);
            if (quoteFilter.DateTo != DateTime.MinValue)
                quotesQueryable = quotesQueryable.Where(v => v.Date < quoteFilter.DateTo);

            switch (quoteFilter.SortType)
            {
                case SortType.Newest:
                    quotesQueryable = quotesQueryable.OrderByDescending(v => v.Date);
                    break;
                case SortType.Oldest:
                    quotesQueryable = quotesQueryable.OrderBy(v => v.Date);
                    break;
                case SortType.Views:
                    quotesQueryable = quotesQueryable.OrderByDescending(v => v.ViewsCount);
                    break;
                case SortType.Downloads:
                    quotesQueryable = quotesQueryable.OrderByDescending(v => v.DownloadsCount);
                    break;
                case SortType.Random:
                    quotesQueryable = quotesQueryable.OrderBy(v => Guid.NewGuid());
                    break;
                default:
                    break;
            }

            await HttpContext.InsertPaginationParametersInResponse(quotesQueryable,
                quoteFilter.RecordsPerPage);

            var quotes = await quotesQueryable.Paginate(quoteFilter.Pagination).ToListAsync();

            return quotes;
        }
    }
}
