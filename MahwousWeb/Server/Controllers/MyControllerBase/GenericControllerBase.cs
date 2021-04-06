using MahwousWeb.Persistent;
using MahwousWeb.Server.Helpers;
using MahwousWeb.Models.Filters;
using MahwousWeb.Models.Models;
using MahwousWeb.Models.Pagination;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace MahwousWeb.Server.Controllers.MyControllerBase
{
    public abstract class GenericControllerBase<TModel, TFilter> : ControllerBase, IGenericControllerBase<TModel, TFilter>
        where TModel : ModelBase
        where TFilter : IFilter<TModel>
    {

        #region Fields And Constructors

        protected readonly DbSet<TModel> table;

        protected const string noImage = "https://www.mahwous.com/website/images/no_image.jpg";

        protected readonly ApplicationDbContext context;
        protected readonly IFileStorageService fileStorageService;

        public GenericControllerBase(ApplicationDbContext context,
            IFileStorageService fileStorageService)
        {
            this.context = context;
            this.fileStorageService = fileStorageService;
            table = context.Set<TModel>();
        }
        #endregion



        [HttpPost]
        [Authorize]
        public virtual async Task<ActionResult<int>> Post(TModel entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }


        [HttpPut]
        [Authorize]
        public virtual async Task<IActionResult> Put(TModel entity)
        {
            var old = await table.FirstOrDefaultAsync(c => c.Id == entity.Id);

            if (old == null) { return NotFound(); }

            context.Entry(old).CurrentValues.SetValues(entity);

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var entity = await table.FirstOrDefaultAsync(c => c.Id == id);

            if (entity == null) { return NotFound(); }

            context.Remove(entity);
            await context.SaveChangesAsync();
            return NoContent();
        }


        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TModel>> Get(int id)
        {
            return await table.FirstOrDefaultAsync(c => c.Id == id);
        }


        [HttpGet("GetRandom")]
        public async Task<ActionResult<TModel>> GetRandom()
        {
            return await table.OrderBy(v => Guid.NewGuid()).FirstOrDefaultAsync();
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<ICollection<TModel>>> GetAll()
        {
            return await table.ToListAsync();
        }


        [HttpGet("GetPaginated")]
        public async Task<ActionResult<ICollection<TModel>>> GetPaginated([FromQuery] PaginationDetails pagination)
        {
            var queryable = table.AsQueryable();
            await HttpContext.InsertPaginationParametersInResponse(queryable, pagination);
            return await queryable.Paginate(pagination).ToListAsync();
        }


        [HttpGet("GetCount")]
        public async Task<ActionResult<int>> GetCount()
        {
            return await table.CountAsync();
        }


        [HttpGet("GetCountFiltered")]
        public async Task<ActionResult<int>> GetCount(IFilter<TModel> filter)
        {
            return await table.CountAsync();
        }


        [HttpPost("GetFiltered")]
        public async Task<ActionResult<ICollection<TModel>>> GetFiltered(TFilter filter)
        {
            var queryable = table.Filter(filter);
            await HttpContext.InsertPaginationParametersInResponse(queryable, filter.Pagination);
            return await queryable.Paginate(filter.Pagination).ToListAsync();
        }


        [HttpPut("IncrementViews/{id}")]
        public async Task<IActionResult> IncrementViews(int id)
        {
            TModel model = await table.FirstOrDefaultAsync(s => s.Id == id);
            model.ViewsCount++;
            context.SaveChanges();

            return Ok();
        }




        //public abstract Task<ActionResult<Informations>> GetInformations();
        //public abstract Task<ActionResult<Informations>> GetInformations(IFilter<TModel> filter);



        // this is for test.. if this work fine then delete the section in the bottom

        [HttpGet("GetInformations")]
        public virtual async Task<ActionResult<Informations>> GetInformations()
        {
            return await GetEntityInformations();
        }


        [HttpPost("GetInformationsFiltered")]
        public virtual async Task<ActionResult<Informations>> GetInformations(TFilter filter)
        { 
            return await GetEntityInformations(filter); 
        }


        private async Task<Informations> GetEntityInformations(IFilter<TModel> filter = null)
        {
            var entities = table.Filter(filter);

            Informations informations = new Informations 
            {
                Count = await entities.CountAsync(),
                ViewsCount = await entities.SumAsync(s => (long)s.ViewsCount)
            };

            return informations;
        }






        //// this should Working Fine
        //[HttpGet("GetInformations")]
        //public override async Task<ActionResult<Informations>> GetInformations()
        //{
        //    return await GetEntityInformations();
        //}


        //[HttpPost("GetInformationsFiltered")]
        //public async Task<ActionResult<Informations>> GetInformations(TFilter filter)
        //{ return await GetInformations((IFilter<TModel>)filter); }

        //[NonAction]
        //public override async Task<ActionResult<Informations>> GetInformations(IFilter<TModel> filter)
        //{
        //    return await GetEntityInformations(filter);
        //}

        //private async Task<Informations> GetEntityInformations(IFilter<TModel> filter = null)
        //{
        //    var notifications = table.Filter(filter);

        //    Informations informations = new Informations();
        //    informations.Count = await notifications.CountAsync();
        //    informations.ViewsCount = await notifications.SumAsync(s => (long)s.ViewsCount);

        //    return informations;
        //}
    }
}
