using HouseRentSystem.Core.Contracts;
using HouseRentSystem.Core.Models.Home;
using HouseRentSystem.Core.Services;
using HouseRentSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HouseRentSystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> logger;
        private readonly IHouseService houseService;

        public HomeController(
            ILogger<HomeController> logger
            ,IHouseService houseService
            )
        {
            this.logger = logger;
            this.houseService = houseService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await houseService.LastThreeHouses();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
