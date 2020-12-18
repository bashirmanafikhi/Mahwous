using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MahwousWeb.Server.Controllers.MyControllerBase
{
    public interface IGenericControllerBase<TModel, TFilter>
        where TModel : ModelBase
        where TFilter : IFilter<TModel>
    {
        Task<ActionResult<int>> Post(TModel entity);
        Task<IActionResult> Put(TModel entity);
        Task<IActionResult> Delete(int id);

        Task<ActionResult<TModel>> Get(int id);
        Task<ActionResult<TModel>> GetRandom();
        Task<ActionResult<ICollection<TModel>>> GetAll();
        Task<ActionResult<ICollection<TModel>>> GetPaginated([FromQuery] PaginationDetails pagination);
        Task<ActionResult<ICollection<TModel>>> GetFiltered(TFilter filter);

        Task<ActionResult<int>> GetCount();
        Task<ActionResult<int>> GetCount(IFilter<TModel> filter);

        Task<ActionResult<Informations>> GetInformations();
        Task<ActionResult<Informations>> GetInformations(TFilter filter);

        Task<IActionResult> IncrementViews(int id);
    }
}
