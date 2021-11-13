//using Mahwous.Core.Entities;
//using Mahwous.Service.Services;
//using Mahwous.Service.ViewModels.VideoStatuses;
//using System;
//using System.IO;
//using System.Threading.Tasks;

//namespace Mahwous.Service.Repositories
//{
//    public class VideoRepository : StatusRepository<VideoStatus>
//    {
//        public VideoRepository(IHttpService httpService, string url) : base(httpService, url)
//        { }

//        public async Task<int> Add(VideoStatus video, Stream coverFile, Stream videoFile)
//        {
//            var response = await httpService.PostMultipartContent<VideoStatus, int>(url, video);

//            if (!response.Success)
//                throw new ApplicationException(await response.GetBody());

//            return response.Response;
//        }

//        public async Task<int> Add(CreateVideoStatusCommand video)
//        {
//            var response = await httpService.PostMultipartContent<CreateVideoStatusCommand, int>(url, video);

//            if (!response.Success)
//                throw new ApplicationException(await response.GetBody());

//            return response.Response;
//        }

//        public async Task Update(VideoStatus video, Stream coverFile, Stream videoFile)
//        {
//            var response = await httpService.PutMultipartContent(url, video);

//            if (!response.Success)
//                throw new ApplicationException(await response.GetBody());
//        }
//    }
//}
