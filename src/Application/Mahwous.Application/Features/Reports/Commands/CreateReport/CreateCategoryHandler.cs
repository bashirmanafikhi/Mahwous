using AutoMapper;
using Mahwous.Application.Extensions;
using Mahwous.Core.Entities;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.Reports
{
    public class CreateReportHandler : IRequestHandler<CreateReportCommand, int>
    {

        private readonly IReportRepository reportRepository;
        private readonly IFileStorageService fileService;
        private readonly IMapper mapper;

        public CreateReportHandler(IReportRepository reportRepository, IFileStorageService fileService, IMapper mapper)
        {
            this.reportRepository = reportRepository;
            this.fileService = fileService;
            this.mapper = mapper;
        }


        public async Task<int> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            // Mapping
            Report report = mapper.Map<Report>(request);

            // Save Data
            await reportRepository.AddAsync(report);
            return report.Id;
        }
    }
}
