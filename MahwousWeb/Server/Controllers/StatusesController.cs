using Mahwous.Core.Models;
using MahwousWeb.API.Controllers.MyControllerBase;
using MahwousWeb.API.Helpers;
using MahwousWeb.Models.Filters;
using MahwousWeb.Persistent;
using Microsoft.AspNetCore.Mvc;

namespace MahwousWeb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusesController : GenericStatusesControllerBase<Status, StatusFilterBase<Status>>
    {
        public StatusesController(ApplicationDbContext context, IFileStorageService fileStorageService)
            : base(context, fileStorageService) { }

    }
}
