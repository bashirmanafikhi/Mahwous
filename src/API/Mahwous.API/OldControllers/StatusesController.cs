using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.API.Controllers.MyControllerBase;
using MahwousWeb.Persistent;
using Microsoft.AspNetCore.Mvc;
using Mahwous.Core.Interfaces;

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
