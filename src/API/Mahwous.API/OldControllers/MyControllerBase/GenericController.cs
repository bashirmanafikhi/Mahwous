using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using MahwousWeb.Persistent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Mahwous.Core.Interfaces;

namespace Mahwous.API.Controllers.MyControllerBase
{
    public abstract class GenericController<TModel, TFilter> : GenericControllerBase<TModel, TFilter>, IGenericControllerBase<TModel, TFilter>
        where TModel : BaseEntity
        where TFilter : IFilter<TModel>
    {
        public GenericController(ApplicationDbContext context,
            IFileStorageService fileStorageService) : base(context, fileStorageService)
        { }

        [HttpPost]
        [Authorize]
        public virtual async Task<ActionResult<int>> Post(TModel entity)
        {
            try
            {
                context.Add(entity);
                await context.SaveChangesAsync();
                return entity.Id;
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "error while adding data.");
            }
        }


        [HttpPut]
        [Authorize]
        public virtual async Task<IActionResult> Put(TModel entity)
        {
            try
            {
                var old = await table.FirstOrDefaultAsync(c => c.Id == entity.Id);

                if (old == null) { return NotFound(); }

                context.Entry(old).CurrentValues.SetValues(entity);

                await context.SaveChangesAsync();
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "error while updating data.");
            }
        }
    }
}
