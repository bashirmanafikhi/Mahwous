using Mahwous.Core.Dtos;
using Mahwous.Service.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mahwous.Service.Repositories
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly IHttpService httpService;
        private readonly string baseURL = "api/accounts";

        public AccountsRepository(HttpClient httpClient)
        {
            this.httpService = new HttpService(httpClient);
        }
        public AccountsRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }


        public async Task<UserToken> Register(RegisterUserInfo userInfo)
        {
            var httpResponse = await httpService.Post<RegisterUserInfo, UserToken>($"{baseURL}/register", userInfo);

            if (!httpResponse.Success)
            {
                throw new ApplicationException(await httpResponse.GetBody());
            }

            return httpResponse.Response;
        }

        public async Task<UserToken> Login(UserInfo userInfo)
        {
            var httpResponse = await httpService.Post<UserInfo, UserToken>($"{baseURL}/login", userInfo);

            if (!httpResponse.Success)
            {
                throw new ApplicationException(await httpResponse.GetBody());
            }

            return httpResponse.Response;
        }

        //public async Task<UserToken> RenewToken()
        //{
        //    var response = await httpService.Get<UserToken>($"{baseURL}/RenewToken");

        //    if (!response.Success)
        //    {
        //        throw new ApplicationException(await response.GetBody());
        //    }

        //    return response.Response;
        //}
    }
}
