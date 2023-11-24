using AuthStateProviderSample.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace AuthStateProviderSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MYStateService _stateService;
        public string username { get; set; }


        public HomeController(ILogger<HomeController> logger,MYStateService stateService)
        {
            _logger = logger;
            //_username = User.Identity != null ? (User.Identity.Name != null ? User.Identity.Name : "Nulll") : "Nulll";
            _stateService = stateService;
        }

        public IActionResult Index()
        {
            ViewBag.Username = _stateService.Username;
            return View();
        }

        public IActionResult Privacy()
        {
            _stateService.Username = "UsernameInPrivacy";
            ViewBag.asd = _stateService.Username;

            _logger.LogTrace("sf654sdf654sd65f6sdf");

            return View();
        }

        public async Task<IActionResult> SignIn()
        {
            var claims = new List<Claim>
            {
                new  Claim(ClaimTypes.Name,"MyUsername"),
                new  Claim(ClaimTypes.Role,"Admin"),
            };
            var Identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(Identity);
            AuthenticationProperties options = new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = false,
                ExpiresUtc = DateTimeOffset.UtcNow.AddSeconds(30),
            };
            await HttpContext.SignInAsync(principal,options);
            return RedirectToAction("Index");
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}