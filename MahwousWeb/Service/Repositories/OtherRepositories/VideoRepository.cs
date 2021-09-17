using MahwousWeb.Models.Filters;
using MahwousWeb.Models.Models;
using MahwousWeb.Models.Pagination;
using MahwousWeb.Service.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MahwousWeb.Service.Repositories
{
    public class VideoRepository : StatusRepository<VideoStatus>
    {
        public VideoRepository(IHttpService httpService, string url) : base(httpService, url)
        { }

        public async Task<int> Add(VideoStatus video, Stream coverFile, Stream videoFile)
        {
            var response = await httpService.PostMultipartContent<VideoStatus, int>(url, video,
                new KeyValuePair<string, Stream>("coverFile", coverFile),
            new KeyValuePair<string, Stream>("videoFile", videoFile));

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());

            return response.Response;
        }

        public async Task Update(VideoStatus video, Stream coverFile, Stream videoFile)
        {
            var response = await httpService.PutMultipartContent(url, video,
                new KeyValuePair<string, Stream>("coverFile", coverFile),
            new KeyValuePair<string, Stream>("videoFile", videoFile));

            if (!response.Success)
                throw new ApplicationException(await response.GetBody());
        }
    }
}
