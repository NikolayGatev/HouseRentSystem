using HouseRentSystem.Core.Contracts;
using HouseRentSystem.Core.Extensions;
using HouseRentSystem.Core.Models.House;
using HouseRentSystem.Data.Common;
using HouseRentSystem.Data.Models;
using HouseRentSystem.Web.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Security.Claims;

namespace HouseRentSystem.Web.Controllers
{
    public class HouseController : BaseController
    {
        private readonly IHouseService houseService;
        private readonly IAgentService agentService;
        private readonly ILogger<HouseController> logger;

        public HouseController(
            IHouseService houseService
            ,IAgentService agentService
            ,ILogger<HouseController> logger)
        {
            this.houseService = houseService;
            this.agentService = agentService;
            this.logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]

        public async Task<IActionResult> All([FromQuery]AllHousesQueryModel query)
        {
            var model = await houseService.AllAsyn(
                query.Category
                ,query.SearchTerm
                ,query.Sorting
                ,query.CurrentPage
                ,query.HousesPerPage);

            query.TotalHousesCount = model.TotalHousesCount;
            query.Houses = model.Houses;
            query.Categories = await houseService.AllCategoriesNamesAsync();

            return View(query);
        }

        [HttpGet]

        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            IEnumerable<HouseServiceModel> model;

            if(await agentService.ExistsByIdAsync(userId))
            {
                var agentId = await agentService.GetAgentIdAsync(userId) ?? 0;
                model = await houseService.AllHousesByAgentIdAsync(agentId);
            }
            else
            {
                model = await houseService.AllHousesByUserId(userId);
            }

            return View(model);
        }

        [HttpGet]

        public async Task<IActionResult> Details(int id, string information)
        {
            if(await houseService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await houseService.HouseDetailsByIdAsync(id);

            if(information != model.GetInformation())
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpGet]
        [MustBeAgent]

        public async Task<IActionResult> Add()
        {
            var model = new HouseFormModel()
            {
                Categories = await houseService.AllCategoriesAsync(),
            };
            return View(model);
        }

        [HttpPost]
        [MustBeAgent]

        public async Task<IActionResult> Add(HouseFormModel model)
        {
            if(await houseService.CategoryExistsAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }

            if(ModelState.IsValid == false)
            {
                model.Categories = await houseService.AllCategoriesAsync();

                return View(model);
            }

            int? agentId = await agentService.GetAgentIdAsync(User.Id());

            int newHouseId = await houseService.CreateAsync(model, agentId ?? 0);

            return RedirectToAction(nameof(Details), new {id = newHouseId, information = model.GetInformation()});
        }

        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            if(await houseService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if(await houseService.HasAgentWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            var model = await houseService.GetHouseFormByIdAsync(id);

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, HouseFormModel model)
        {
            if (await houseService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (await houseService.HasAgentWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            if(await houseService.CategoryExistsAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }

            if(ModelState.IsValid == false)
            {
                model.Categories = await houseService.AllCategoriesAsync();

                return View(model);
            }

            await houseService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id = id, information = model.GetInformation() });
        }

        [HttpGet]

        public async Task<IActionResult> Delete(int id)
        {
            if (await houseService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if(await houseService.HasAgentWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            var model = await houseService.GetHouseDetailsFormByIdAsync(id);
            
            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(HouseDetailsViewModel model)
        {
            if (await houseService.ExistAsync(model.Id) == false)
            {
                return BadRequest();
            }

            if ( await houseService.HasAgentWithIdAsync(model.Id, User.Id()) == false)
            {
                return Unauthorized();
            }

            await houseService.DeleteAsync(model.Id);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]

        public async Task<IActionResult> Rent(int id)
        {
            if (await houseService.ExistAsync(id) == false)
            {
                return BadRequest();
            }

            if (await agentService.ExistsByIdAsync(User.Id()))
            {
                return Unauthorized();
            }

            if (await houseService.IsRentedAsync(id))
            {
                return BadRequest();
            }

            await houseService.Rent(id, User.Id());

            return RedirectToAction(nameof(All));
        }

        [HttpPost]

        public async Task<IActionResult> Leave(int id)
        {
            if(await houseService.ExistAsync(id) == false)
            {
                return BadRequest();                  
            }

            try
            {
                await houseService.LeaveAsync(id, User.Id());
            }
            catch (UnauthorizedAccessException uae)
            {
                logger.LogError(uae, "HouseController/Leave");

                return Unauthorized();
            }

            return RedirectToAction(nameof(All));
        }
    }
}
