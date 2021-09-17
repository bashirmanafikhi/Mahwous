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
    public class Repository<TEntity> : RepositoryBase<TEntity>, IRepository<TEntity> where TEntity : ModelBase
    {
        public Repository(IHttpService httpService, string url) : base(httpService, url)
        { }

        public async Task<int> Add(TEntity entity)
        {
            var response = await httpService.Post<TEntity, int>(url, entity);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task Update(TEntity entity)
        {
            var response = await httpService.Put(url, entity);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
