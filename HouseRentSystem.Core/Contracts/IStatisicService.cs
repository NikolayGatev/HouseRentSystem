using HouseRentSystem.Core.Models.Statistics;

namespace HouseRentSystem.Core.Contracts
{
    public interface IStatisicService
    {
        Task<StatisticServiceModel> TotalAsync();
    }
}
