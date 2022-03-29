﻿using Mahwous.Core.Pagination;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mahwous.Service.Services
{
    public static class IHttpServiceExtensionMethods
    {
        public static async Task<T> GetHelper<T>(this IHttpService httpService, string url)
        {
            var response = await httpService.Get<T>(url);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

    }
}
