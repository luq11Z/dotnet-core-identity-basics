using dotnet_core_identity_basics.Extensions;
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
            throw new Exception("Erro");
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

        [ClaimsAuthorize("Products", "Read")]
        public IActionResult ClaimsCustom()
        {
            return View("Secret");
        }

        [Route("Error/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelError = new ErrorViewModel();

            if (id == 500)
            {
                modelError.Message = "An error ocurred! Please try again later or contact our support.";
                modelError.Title = "An error ocurred!";
                modelError.ErrorCode = id;
            }
            else if (id == 404)
            {
                modelError.Message = "Page does not exist! <br/> If you have any questions contact our support.";
                modelError.Title = "Ops! Page not found.";
                modelError.ErrorCode = id;
            }
            else if (id == 403)
            {
                modelError.Message = "You dont have permissions.";
                modelError.Title = "Access denied.";
                modelError.ErrorCode = id;
            }
            else
            {
                return StatusCode(404);
            }

            return View("Error", modelError);
        }
    }
}
