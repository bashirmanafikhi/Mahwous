using AutoMapper;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.ImageStatuses
{
    public class GetImageStatusDetailsHandler : IRequestHandler<GetImageStatusDetailsQuery, GetImageStatusDetailsResponse>
    {
        private readonly IImageStatusRepository imageRepository;
        private readonly IMapper mapper;

        public GetImageStatusDetailsHandler(IImageStatusRepository imageRepository, IMapper mapper)
        {
            this.imageRepository = imageRepository;
            this.mapper = mapper;
        }

        public async Task<GetImageStatusDetailsResponse> Handle(GetImageStatusDetailsQuery request, CancellationToken cancellationToken)
        {
            var image = await imageRepository.GetByIdAsync(request.Id);
            var response = mapper.Map<GetImageStatusDetailsResponse>(image);
            return response;
        }
    }
}
