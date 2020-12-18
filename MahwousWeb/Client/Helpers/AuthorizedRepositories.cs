using MahwousWeb.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MahwousWeb.Client.Helpers
{
    public class AuthorizedRepositories : MahwousRepositories
    {
        public AuthorizedRepositories(HttpClient httpClient) : base(httpClient)
        {

        }
    }
    public class NotAuthorizedRepositories : MahwousRepositories
    {
        public NotAuthorizedRepositories(HttpClient httpClient) : base(httpClient)
        {

        }
    }
}
