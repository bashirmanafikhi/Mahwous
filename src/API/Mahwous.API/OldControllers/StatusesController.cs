using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.API.Controllers.MyControllerBase;
using Mahwous.API.Helpers;
using MahwousWeb.Persistent;
using Microsoft.AspNetCore.Mvc;

namespace Mahwous.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusesController : GenericStatusesControllerBase<Status, StatusFilter<Status>>
    {
        public StatusesController(ApplicationDbContext context, IFileStorageService fileStorageService)
            : base(context, fileStorageService) { }

    }
}
