using AuthStateProviderSample;
using AuthStateProviderSample.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ISampleService, SampleService>();

builder.Services.AddSingleton<MYStateService>();

builder.Services.AddAuthentication(a =>
{
    a.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    a.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    a.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(c =>
{
    c.ExpireTimeSpan = TimeSpan.FromMinutes(1);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}





app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


//app.UseEndpoints(e =>
//{
//    e.MapGet("/endPoint", async context =>
//    {
//        context.Response.ContentType = "text/html";
//         context.Response.StatusCode = 200;
//        await context.Response.WriteAsync("My EndPoint ----------------- ");
//        await context.Response.WriteAsync($"Is In Role Admin : {context.User.IsInRole("Admin")}");
//    });
//});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapGet("/h", () => "Hello World!");

app.MapGet("/mp", async context =>
{
    context.Response.ContentType = "text/html";
    context.Response.StatusCode = 200;
    await context.Response.WriteAsync("My EndPoint ----------------- ");
    await context.Response.WriteAsync($"Is In Role Admin : {context.User.IsInRole("Admin")}");
});

app.Use(async (contect, next) =>
{
    contect.Response.Headers.Add("Dsfsd-Mdsdf","6654565656");
    var x = contect.User.IsInRole("Admin");
    var stateService = app.Services.GetService<MYStateService>();
    if (contect.User.Identity.Name != null)
    {
        stateService.Username = contect.User.Identity.Name;
    }
    contect.Response.Headers.Add("IsAdmin",x.ToString());
    contect.Response.Headers.Add("StateService",stateService == null ? "Null" : stateService.ToString());
    contect.Response.Headers.Add("StateService-Username",stateService.Username ?? "No Username");
    await next();
});

app.Use(async (httpContext, next) => {

    httpContext.Response.Headers.Add("IsInRoleAdmin", httpContext.User.IsInRole("Admin").ToString());
    //if (httpContext.Request.Path.ToString().Contains("MyMiddleware"))
    //{
    //    var identity = httpContext.User != null ? httpContext.User.Identity : null;
    //    var name = identity != null ? identity.Name : "Null";
    //    string a = name ?? "Null";
    //    //string x = $"Hello From MyMiddleware ({name ?? "Null"})";
    //    string x = $"Hello From MyMiddleware ({httpContext.User.IsInRole("Admin")})";
    //    httpContext.Response.Headers.Add("AMyHeader",a);
    //    httpContext.Response.StatusCode = 200;
    //    //httpContext.Response.ContentType = "text/httml";
    //    //await httpContext.Response.WriteAsync(x);
    //}    
    await next();
});

//app.Map();

app.Run();
