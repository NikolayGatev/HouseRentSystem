using HouseRentSystem.Core.Models.House;
using HouseRentSystem.Data.Models;

namespace System.Linq
{
    public static class IQuerableHouseExtention
    {
        public static IQueryable<HouseServiceModel> ProjectToHouseServiceModel(this IQueryable<House> houses)
        {
            return houses
                .Select(house => new HouseServiceModel()
                {
                    Id = house.Id,
                    Address = house.Address,
                    ImageUrl = house.ImageUrl,
                    IsRented = house.RenterId != null,
                    PricePerMonth = house.PricePerMonth,
                    Title = house.Title,
                });
        }
    }
}
