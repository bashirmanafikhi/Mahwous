using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;
using Mahwous.Service.Services;
using Mahwous.Service.ViewModels.Reports;
using System;
using System.Threading.Tasks;

namespace Mahwous.Service.Repositories
{
    public class ReportRepository
    {
        private readonly IHttpService httpService;
        private readonly string url;

        public ReportRepository(IHttpService httpService, string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException($"'{nameof(url)}' cannot be null or empty.", nameof(url));

            this.httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
            this.url = url;
        }

        public async Task<int> Create(CreateReportCommand command)
        {
            var response = await httpService.Post<CreateReportCommand, int>(url, command);

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());

            return response.Response;
        }
    }
}
