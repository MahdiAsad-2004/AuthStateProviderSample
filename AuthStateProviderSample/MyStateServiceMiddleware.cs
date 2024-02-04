using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Security.Principal;

namespace AuthStateProviderSample
{
    public class MYStateServiceMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly WebApplication application;

        public MYStateServiceMiddleware(RequestDelegate next , WebApplication application)
        {
            _next = next;
            this.application = application;
        }


        public async Task Invoke(HttpContext httpContext)
        {
            var stateService = application.Services.GetService<MYStateService>();
            if (httpContext.User.Identity.Name != null)
            {
                stateService.Username = httpContext.User.Identity.Name;
            }
            else
            {
                stateService.Username = "NUlll";
            }
            await _next(httpContext);
        }

    }
}