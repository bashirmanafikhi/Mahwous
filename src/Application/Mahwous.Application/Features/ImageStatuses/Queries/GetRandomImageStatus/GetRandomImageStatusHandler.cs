using AutoMapper;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.ImageStatuses
{
    public class GetRandomImageStatusHandler : IRequestHandler<GetRandomImageStatusQuery, GetRandomImageStatusResponse>
    {
        private readonly IImageStatusRepository imageRepository;
        private readonly IMapper mapper;

        public GetRandomImageStatusHandler(IImageStatusRepository imageRepository, IMapper mapper)
        {
            this.imageRepository = imageRepository;
            this.mapper = mapper;
        }

        public async Task<GetRandomImageStatusResponse> Handle(GetRandomImageStatusQuery request, CancellationToken cancellationToken)
        {
            var image = await imageRepository.GetRandomAsync();
            var response = mapper.Map<GetRandomImageStatusResponse>(image);
            return response;
        }
    }
}
