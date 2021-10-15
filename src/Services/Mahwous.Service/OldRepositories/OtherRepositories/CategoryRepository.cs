//using Mahwous.Core.Entities;
//using Mahwous.Service.Services;
//using System;
//using System.IO;
//using System.Threading.Tasks;

//namespace Mahwous.Service.Repositories
//{
//    public class CategoryRepository : RepositoryBase<Category>
//    {
//        public CategoryRepository(IHttpService httpService, string url) : base(httpService, url)
//        { }

//        public async Task<int> Add(Category category, Stream coverFile)
//        {
//            var response = await httpService.PostMultipartContent<Category, int>(url, category);

//            if (!response.Success)
//                throw new ApplicationException(await response.GetBody());

//            return response.Response;
//        }

//        public async Task Update(Category category, Stream coverFile)
//        {
//            var response = await httpService.PutMultipartContent(url, category);

//            if (!response.Success)
//                throw new ApplicationException(await response.GetBody());
//        }
//    }
//}
