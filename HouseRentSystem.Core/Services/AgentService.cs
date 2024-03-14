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

        public async Task CreateAsync(string userId, string phoneNumber)
        {
            await repozitory.AddAsync(new Agent() 
            { 
                UserId = userId
                ,PhoneNumber = phoneNumber 
            });

            await repozitory.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(string agentId)
        {
            return await repozitory.AllReadOnly<Agent>()
                .AnyAsync(a => a.UserId == agentId);
        }

        public async Task<bool> UserHasRentsAsync(string userId)
        {
            return await repozitory.AllReadOnly<House>()
                .AnyAsync(h => h.RenterId == userId);
        }

        public async Task<bool> UserWithPhoneNumberExixtsAsync(string phoneNumber)
        {
            return await repozitory.AllReadOnly<Agent>()
                .AnyAsync(a => a.PhoneNumber == phoneNumber);
        }
    }
}
