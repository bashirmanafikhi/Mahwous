using Mahwous.Core.Entities;
using Mahwous.Service.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Mahwous.Service.Repositories
{
    public class ImageRepository : StatusRepository<ImageStatus>
    {
        public ImageRepository(IHttpService httpService, string url) : base(httpService, url)
        { }

        public async Task<int> Add(ImageStatus image, Stream imageFile)
        {
            var response = await httpService.PostMultipartContent<ImageStatus, int>(url, image);

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());

            return response.Response;
        }

        public async Task Update(ImageStatus image, Stream imageFile)
        {
            var response = await httpService.PutMultipartContent(url, image);

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());
        }
    }
}
