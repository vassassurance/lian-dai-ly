using LianAgentPortal.Models;
using LianAgentPortal.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LianAgentPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILianApiService _lianApiService;

        public HomeController(ILogger<HomeController> logger, ILianApiService lianApiService)
        {
            _logger = logger;
            _lianApiService = lianApiService;
		}

        public IActionResult Index()
        {


			if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "Authentication", null);
            }
			_lianApiService.SetUserInfo(User.Identity.Name);
			_lianApiService.CalculateInsuranceFee();

			return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}