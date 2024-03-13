﻿using HouseRentSystem.Core.Contracts;
using HouseRentSystem.Core.Models.Agent;
using HouseRentSystem.Data.Common;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentSystem.Web.Controllers
{
    public class AgentController : BaseController
    {
        private readonly IAgentService agentService;

        public AgentController(
            IAgentService agentService)
        {
            this.agentService = agentService;
        }

        [HttpGet]

        public async Task<IActionResult> Become()
        {
            var model = new BecomeAgentFormModel();

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Become(BecomeAgentFormModel model)
        {
            return RedirectToAction(nameof(HouseControler.All), "House");
        }
    }
}
