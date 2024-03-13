using HouseRentSystem.Core.Contracts;
using HouseRentSystem.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentSystem.Core.Services
{
    public class AgentService : IAgentService
    {
        private readonly Repository repozitory;

        public AgentService(Repository repozitory)
        {
            this.repozitory = repozitory;
        }
    }
}
