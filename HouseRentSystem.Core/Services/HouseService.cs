using HouseRentSystem.Core.Contracts;
using HouseRentSystem.Core.Models.Home;
using HouseRentSystem.Data.Common;
using HouseRentSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentSystem.Core.Services
{
    public class HouseService : IHouseService
    {
        private readonly IRepozitory repozitory;

        public HouseService(IRepozitory repozitory)
        {
            this.repozitory = repozitory;
        }

        public async Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses()
        {
            return await repozitory
                .AllReadOnly<House>()
                .OrderByDescending(h => h.Id)
                .Take(3)
                .Select(h => new HouseIndexServiceModel()
                {
                    Id = h.Id,
                    ImageUrl = h.ImageUrl,
                    Title = h.Title,
                })
                .ToListAsync();
        }
    }
}
