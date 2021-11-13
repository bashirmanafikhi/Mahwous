//using Mahwous.Core.Entities;
//using Mahwous.Service.Services;
//using System;
//using System.IO;
//using System.Threading.Tasks;

//namespace Mahwous.Service.Repositories
//{
//    public class AppRepository : RepositoryBase<MobileApp>
//    {
//        public AppRepository(IHttpService httpService, string url) : base(httpService, url)
//        { }

//        public async Task<int> Add(MobileApp app, Stream coverFile)
//        {
//            var response = await httpService.PostMultipartContent<MobileApp, int>(url, app);

//            if (!response.Success)
//                throw new ApplicationException(await response.GetBody());

//            return response.Response;
//        }

//        public async Task Update(MobileApp app, Stream coverFile)
//        {
//            var response = await httpService.PutMultipartContent(url, app);

//            if (!response.Success)
//                throw new ApplicationException(await response.GetBody());
//        }
//    }
//}
