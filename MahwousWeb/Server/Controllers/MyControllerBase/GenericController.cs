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
using Microsoft.AspNetCore.Http;

namespace MahwousWeb.Server.Controllers.MyControllerBase
{
    public abstract class GenericController<TModel, TFilter> : GenericControllerBase<TModel, TFilter>, IGenericControllerBase<TModel, TFilter>
        where TModel : ModelBase
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
