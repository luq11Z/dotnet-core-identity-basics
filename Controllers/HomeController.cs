using dotnet_core_identity_basics.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_core_identity_basics.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[Authorize] ->TO MAKE SURE USER IS AUTHENTICATED
        [Authorize(Roles = "Admin, Manager")] //Roles based
        public IActionResult Secret()
        {
            return View();
        }

        [Authorize(Policy = "CanDelete")] //Claims
        public IActionResult SecretClaim()
        {
            return View("Secret");
        }

        [Authorize(Policy = "CanWrite")]
        public IActionResult SecretClaimWrite()
        {
            return View("Secret");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
