using Mahwous.Core.Entities;
using MahwousWeb.Service.Services;
using System;
using System.Threading.Tasks;

namespace MahwousWeb.Service.Repositories
{
    public class Repository<TEntity> : RepositoryBase<TEntity>, IRepository<TEntity> where TEntity : BaseEntity
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
