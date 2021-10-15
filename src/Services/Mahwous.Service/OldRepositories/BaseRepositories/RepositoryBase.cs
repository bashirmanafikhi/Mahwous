﻿//using Mahwous.Core.Entities;
//using Mahwous.Core.Filters;
//using Mahwous.Core.General;
//using Mahwous.Core.Pagination;
//using Mahwous.Service.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Mahwous.Service.Repositories
//{
//    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
//    {
//        protected string url = "api/statuses";

//        protected readonly IHttpService httpService;

//        public RepositoryBase(IHttpService httpService, string url)
//        {
//            this.httpService = httpService;
//            this.url = url;
//        }

//        public async Task Delete(int id)
//        {
//            var response = await httpService.Delete($"{url}/{id}");
//            if (!response.Success)
//            {
//                throw new ApplicationException(await response.GetBody());
//            }
//        }

//        public async Task<TEntity> Get(int id)
//        {
//            var response = await httpService.Get<TEntity>($"{url}/{id}");
//            if (!response.Success)
//            {
//                throw new ApplicationException(await response.GetBody());
//            }
//            return response.Response;
//        }

//        public async Task<TEntity> GetRandom()
//        {
//            return await httpService.GetHelper<TEntity>($"{url}/GetRandom");
//        }

//        public async Task<ICollection<TEntity>> GetAll()
//        {
//            return await httpService.GetHelper<ICollection<TEntity>>($"{url}/GetAll");
//        }

//        public async Task<PaginatedResponse<ICollection<TEntity>>> GetPaginated(PaginationDetails pagination)
//        {
//            return await httpService.GetHelper<ICollection<TEntity>>($"{url}/GetPaginated", pagination);
//        }

//        public async Task<PaginatedResponse<ICollection<TEntity>>> GetFiltered(IFilter<TEntity> filter)
//        {
//            var responseHTTP = await httpService.Post<IFilter<TEntity>, ICollection<TEntity>>($"{url}/GetFiltered", filter);
//            var totalAmountPages = int.Parse(responseHTTP.HttpResponseMessage.Headers.GetValues("totalAmountPages").FirstOrDefault());
//            var paginatedResponse = new PaginatedResponse<ICollection<TEntity>>()
//            {
//                Response = responseHTTP.Response,
//                TotalPages = totalAmountPages
//            };

//            return paginatedResponse;
//        }

//        public async Task<int> GetCount()
//        {
//            return await httpService.GetHelper<int>($"{url}/GetCount");
//        }

//        public async Task<int> GetCount(IFilter<TEntity> filter)
//        {
//            var responseHTTP = await httpService.Post<IFilter<TEntity>, int>($"{url}/GetCountFiltered", filter);
//            return responseHTTP.Response;
//        }

//        public async Task<Informations> GetInformations()
//        {
//            return await httpService.GetHelper<Informations>($"{url}/GetInformations");
//        }

//        public async Task<Informations> GetInformations(IFilter<TEntity> filter)
//        {
//            var responseHTTP = await httpService.Post<IFilter<TEntity>, Informations>($"{url}/GetInformationsFiltered", filter);
//            return responseHTTP.Response;
//        }

//        public async Task IncrementViews(int id)
//        {
//            var response = await httpService.Put($"{url}/IncrementViews/{id}");
//            if (!response.Success)
//            {
//                throw new ApplicationException(await response.GetBody());
//            }
//        }
//    }
//}
