using AuthStateProviderSample.Models;
using AuthStateProviderSample.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace AuthStateProviderSample.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MYStateService _stateService;
        private readonly ISampleService _sampleService;

        public string username { get; set; }


        public UserController(ILogger<HomeController> logger,MYStateService stateService,ISampleService sampleService)
        {
            _logger = logger;
            _stateService = stateService;
            _sampleService = sampleService;
        }

        public async Task<IActionResult> Index()
        {
            //_stateService.Username = "UsernameIn(UserController)";
            ViewBag.az = _stateService.Username;

            await _sampleService.CreateEntity("Course");
            
            return View();
        }
    }
}