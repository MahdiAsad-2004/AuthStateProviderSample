using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Security.Principal;

namespace AuthStateProviderSample
{
    public class MYStateService
    {
        public string Username { get; set; } = "Null";

        public bool IsAdmin { get; set; } = false;



        //private readonly HttpClient _HttpClient;
        //public UserIdentity User { get; set; } = new UserIdentity();
        //public MYStateService(HttpClient httpClient)
        //{
        //    _HttpClient = httpClient;
        //    _HttpClient.BaseAddress = new Uri("https://localhost:7120");
        //}

        //public async Task<bool> RefreshCurrentUser()
        //{
        //    var anonymuos = await _HttpClient.GetFromJsonAsync<UserIdentity>("/Home/CurrentUser");
        //    if(anonymuos is null || anonymuos.IsAuth == false) 
        //    {
        //        User = new UserIdentity();
        //        return false;
        //    }
        //    else
        //    {
        //        List<Claim> claims = new List<Claim>()
        //        {
        //            new Claim(ClaimTypes.NameIdentifier , anonymuos.NameIdentifier),
        //            new Claim(ClaimTypes.Name , anonymuos.Name),
        //        };
        //        foreach (var role in anonymuos.Roles)
        //        {
        //            claims.Add(new Claim(ClaimTypes.Role, role));
        //        }
        //        ClaimsIdentity identity = new ClaimsIdentity(claims, anonymuos.AuthType);
        //        AuthenticationState authenticationState = new AuthenticationState(new ClaimsPrincipal(identity));
        //        User = anonymuos;
        //        return true;
        //    }
        //}

        //public async Task MarkUserSignOut()
        //{
        //    User = new UserIdentity();
        //}

    }
}