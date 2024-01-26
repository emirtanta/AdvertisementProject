using AdvertisementProject.Business.Interfaces;
using AdvertisementProject.WebUI.Extensions;
using AdvertisementProject.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdvertisementProject.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProvidedServiceService _providedService;
        private readonly IAdvertisementService _advertisementService;

        public HomeController(ILogger<HomeController> logger, IProvidedServiceService providedService, IAdvertisementService advertisementService)
        {
            _logger = logger;
            _providedService = providedService;
            _advertisementService = advertisementService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _providedService.GetAllServiceAsync();

            return this.ResponseView(response);
        }

        public async Task<IActionResult> HumanResource()
        {
            var response=await _advertisementService.GetActivesServiceAsync();

            return this.ResponseView(response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
