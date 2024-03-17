using HouseRentSystem.Core.Enumerations;
using HouseRentSystem.Core.Models.Home;
using HouseRentSystem.Core.Models.House;

namespace HouseRentSystem.Core.Contracts
{
    public interface IHouseService
    {
        Task<IEnumerable<HouseIndexServiceModel>> LastThreeHousesAsync();

        Task<IEnumerable<HouseCategoryServiceModel>> AllCategoriesAsync();

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<int> CreateAsync(HouseFormModel model, int agentId);

        Task<HouseQueryServiceModel> AllAsyn(
            string? category = null
            , string? searchTerm = null
            , HouseSorting sorting = HouseSorting.Newest
            , int curentPage = 1
            , int housesPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNamesAsync();

        Task<IEnumerable<HouseServiceModel>> AllHousesByAgentIdAsync(int agentId);

        Task<IEnumerable<HouseServiceModel>> AllHousesByUserId(string userId);

        Task<bool> ExistAsync(int Id);

        Task<HouseDetailsServiceModel> HouseDetailsByIdAsync(int id);

        Task EditAsync(int houseId, HouseFormModel model);

        Task<bool> HasAgentWithIdAsync(int houseId, string userId);

        Task<HouseFormModel?> GetHouseFormByIdAsync(int id);

        Task<HouseDetailsViewModel?> GetHouseDetailsFormByIdAsync(int id);

        Task DeleteAsync(int id);

        Task<bool> IsRentedAsync(int id);

        Task<bool> IsRentedByUserWhitIdAsync(int houseId, string userId);

        Task Rent(int houseId, string userId);

        Task Leave(int houseId);
    }
}
