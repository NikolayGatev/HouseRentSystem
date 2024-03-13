using HouseRentSystem.Core.Contracts;
using HouseRentSystem.Data.Common;
using HouseRentSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentSystem.Core.Services
{
    public class AgentService : IAgentService
    {
        private readonly Repository repozitory;

        public AgentService(Repository repozitory)
        {
            this.repozitory = repozitory;
        }

        public Task CreateAsync(string userId, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsByIdAsync(string agentId)
        {
            return await repozitory.AllReadOnly<Agent>()
                .AnyAsync(a => a.UserId == agentId);
        }

        public Task<bool> UserHasRentsAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserWithPhoneNumberExixtsAsync(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
