using Mahwous.Core.Entities;
using MahwousWeb.Service.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MahwousWeb.Service.Repositories
{
    public class ImageRepository : StatusRepository<ImageStatus>
    {
        public ImageRepository(IHttpService httpService, string url) : base(httpService, url)
        { }

        public async Task<int> Add(ImageStatus image, Stream imageFile)
        {
            var response = await httpService.PostMultipartContent<ImageStatus, int>(url, image,
                new KeyValuePair<string, Stream>("imageFile", imageFile));

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());

            return response.Response;
        }

        public async Task Update(ImageStatus image, Stream imageFile)
        {
            var response = await httpService.PutMultipartContent(url, image,
                new KeyValuePair<string, Stream>("imageFile", imageFile));

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());
        }
    }
}
