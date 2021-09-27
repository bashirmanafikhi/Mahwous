﻿using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MahwousWeb.Client.Auth
{
    public class DummyAuthenticationStateProvider : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //await Task.Delay(3000);
            var anonymous = new ClaimsIdentity(new List<Claim>() {
                new Claim("key1", "value1"),
                new Claim(ClaimTypes.Name, "Bashir"),
                new Claim(ClaimTypes.Role, "Admin")
            }, "test");
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
        }
    }
}
