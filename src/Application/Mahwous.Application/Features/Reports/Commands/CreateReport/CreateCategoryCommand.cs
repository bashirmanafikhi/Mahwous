using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Mahwous.Application.Features.Reports
{
    public class CreateReportCommand : IRequest<int>, IMapTo<Report>
    {
        public string Details { get; set; }
        public string ViolatorId { get; set; }
    }
}
