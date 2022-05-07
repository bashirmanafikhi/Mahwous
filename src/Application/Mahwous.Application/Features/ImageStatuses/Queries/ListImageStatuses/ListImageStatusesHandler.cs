using AutoMapper;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.ImageStatuses
{
    public class ListImageStatusesHandler : IRequestHandler<ListImageStatusesQuery, ListImageStatusesResponse>
    {
        private readonly IImageStatusRepository imageRepository;
        private readonly IMapper mapper;

        public ListImageStatusesHandler(IImageStatusRepository imageRepository, IMapper mapper)
        {
            this.imageRepository = imageRepository;
            this.mapper = mapper;
        }

        public async Task<ListImageStatusesResponse> Handle(ListImageStatusesQuery request, CancellationToken cancellationToken)
        {
            var filter = mapper.Map<ImageFilter>(request.Filter);
            var imageStatuses = await imageRepository.ListAllAsync(filter);
            var response = mapper.Map<ListImageStatusesResponse>(imageStatuses);
            return response;
        }
    }
}
