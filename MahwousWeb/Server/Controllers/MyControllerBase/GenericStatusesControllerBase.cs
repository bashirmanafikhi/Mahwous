using MahwousWeb.Server.Data;
using MahwousWeb.Server.Helpers;
using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MahwousWeb.Server.Controllers.MyControllerBase
{
    public abstract class GenericStatusesControllerBase<TModel, TFilter> : GenericControllerBase<TModel, TFilter>
        where TModel : Status
        where TFilter : IFilter<TModel>
    {

        public GenericStatusesControllerBase(ApplicationDbContext context, IFileStorageService fileStorageService) 
            : base(context, fileStorageService)
        {

        }


        //[HttpGet("{id}")]
        public override async Task<ActionResult<TModel>> Get(int id)
        {
            var status = await table
                .Include(q => q.StatusCategories)
                .ThenInclude(sc => sc.Category)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (status == null)
            {
                return NotFound();
            }

            return status;
        }



        //[HttpGet("GetInformations")]
        public override async Task<ActionResult<Informations>> GetInformations()
        {
            return await GetStatusesInformations();
        }


        //[HttpPost("GetInformationsFiltered")]
        public override async Task<ActionResult<Informations>> GetInformations(TFilter filter)
        {
            return await GetStatusesInformations(filter);
        }

        private async Task<Informations> GetStatusesInformations(IFilter<TModel> filter = null)
        {
            var statuses = table.Filter(filter);
            Informations informations = new Informations();

            informations.Count = await statuses.CountAsync();

            informations.LikesCount = await statuses.SumAsync(s => (long)s.LikesCount);
            informations.DownloadsCount = await statuses.SumAsync(s => (long)s.DownloadsCount);
            informations.SharesCount = await statuses.SumAsync(s => (long)s.SharesCount);
            informations.ViewsCount = await statuses.SumAsync(s => (long)s.ViewsCount);


            var categoriesStatusCounts = context.Categories.Select(c => new KeyValuePair<string, int>(c.Name, c.StatusCategories.Count));
            informations.CategoriesStatusCounts = new Dictionary<string, int>(categoriesStatusCounts);

            return informations;
        }


        //---------------------- not implementaion methods -------------------------



        [HttpPut("IncrementDownloads/{id}")]
        public async Task<IActionResult> IncrementDownloads(int id)
        {
            Status status = await context.Statuses.FirstOrDefaultAsync(s => s.Id == id);
            status.DownloadsCount++;
            context.SaveChanges();

            return Ok();
        }

        [HttpPut("IncrementShares/{id}")]
        public async Task<IActionResult> IncrementShares(int id)
        {
            Status status = await context.Statuses.FirstOrDefaultAsync(s => s.Id == id);
            status.SharesCount++;
            context.SaveChanges();

            return Ok();
        }

        [HttpPut("IncrementLikes/{id}")]
        public async Task<IActionResult> IncrementLikes(int id)
        {
            Status status = await context.Statuses.FirstOrDefaultAsync(s => s.Id == id);
            status.LikesCount++;
            context.SaveChanges();

            return Ok();
        }

        [HttpPut("DecrementLikes/{id}")]
        public async Task<IActionResult> DecrementLikes(int id)
        {
            Status status = await context.Statuses.FirstOrDefaultAsync(s => s.Id == id);
            status.LikesCount--;
            context.SaveChanges();

            return Ok();
        }

    }
}
