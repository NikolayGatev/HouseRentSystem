using HouseRentSystem.Core.Contracts;
using HouseRentSystem.Core.Models.Statistics;
using HouseRentSystem.Data.Common;
using HouseRentSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentSystem.Core.Services
{
    public class StatisticService : IStatisicService
    {
        private readonly IRepozitory repozitory;

        public StatisticService(IRepozitory repozitory)
        {
            this.repozitory = repozitory;
        }
        public async Task<StatisticServiceModel> TotalAsync()
        {
            int totalHouses = await repozitory.AllReadOnly<House>()
                .CountAsync();

            int totalRent = await repozitory.AllReadOnly<House>()
                .Where(h => h.RenterId != null)
                .CountAsync();

            return new StatisticServiceModel()
            {
                TotalRents = totalRent,
                TotalHouses = totalHouses,
            };
        }
    }
}
