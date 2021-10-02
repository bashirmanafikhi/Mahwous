using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.Core.General;
using Mahwous.Core.Pagination;
using Mahwous.API.Helpers;
using MahwousWeb.Persistent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahwous.Core.Extentions;
using Mahwous.Core.Interfaces;

namespace Mahwous.API.Controllers.MyControllerBase
{
    public abstract class GenericControllerBase<TModel, TFilter> : ControllerBase, IGenericControllerBase<TModel, TFilter>
        where TModel : BaseEntity
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

        [HttpDelete("{id}")]
        [Authorize]
        public virtual async Task<IActionResult> Delete(int id)
        {
            try
            {
                var entity = await table.FirstOrDefaultAsync(c => c.Id == id);

                if (entity == null) { return NotFound(); }

                context.Remove(entity);
                await context.SaveChangesAsync();
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "error while deleting data.");
            }
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
            try
            {
                var queryable = table.AsQueryable();
                await HttpContext.InsertPaginationParametersInResponse(queryable, pagination);
                return await queryable.Paginate(pagination).ToListAsync();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "error while getting paginated data.");
            }
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
            try
            {
                var queryable = table.Filter(filter);
                await HttpContext.InsertPaginationParametersInResponse(queryable, filter.Pagination);
                return await queryable.Paginate(filter.Pagination).ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "error while getting filtered data. " + ex);
            }
        }


        [HttpPut("IncrementViews/{id}")]
        public async Task<IActionResult> IncrementViews(int id)
        {
            try
            {
                TModel model = await table.FirstOrDefaultAsync(s => s.Id == id);
                model.ViewsCount++;
                context.SaveChanges();

                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "error while incrementing views.");
            }
        }

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


        private async Task<ActionResult<Informations>> GetEntityInformations(IFilter<TModel> filter = null)
        {
            try
            {
                var entities = table.Filter(filter);

                Informations informations = new Informations
                {
                    Count = await entities.CountAsync(),
                    ViewsCount = await entities.SumAsync(s => (long)s.ViewsCount)
                };

                return informations;
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "error while getting informations.");
            }
        }
    }
}
