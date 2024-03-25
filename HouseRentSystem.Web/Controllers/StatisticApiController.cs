using HouseRentSystem.Core.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentSystem.Web.Controllers
{
    [Route("api/statistic")]
    [ApiController]

    public class StatisticApiController : ControllerBase
    {
        private readonly IStatisicService statisticService;

        public StatisticApiController(IStatisicService statisticService)
        {
            this.statisticService = statisticService;
        }

        [HttpGet]

        public async Task<IActionResult> GetStatistic()
        {
            var result = await statisticService.TotalAsync();

            return Ok(result);
        }
    }
}
