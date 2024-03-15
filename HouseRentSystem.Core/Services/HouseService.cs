using HouseRentSystem.Core.Contracts;
using HouseRentSystem.Core.Enumerations;
using HouseRentSystem.Core.Models.Home;
using HouseRentSystem.Core.Models.House;
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

        public async Task<IEnumerable<HouseCategoryServiceModel>> AllCategoriesAsync()
        {
            return await repozitory.AllReadOnly<Category>()
                .Select(c => new HouseCategoryServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
            return await repozitory.AllReadOnly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<HouseQueryServiceModel> AllAsyn(
                                                string? category = null
                                                ,string? searchTerm = null
                                                ,HouseSorting sorting = HouseSorting.Newest
                                                ,int curentPage = 1
                                                ,int housesPerPage = 1)
        {
            var housesToShow = repozitory.AllReadOnly<House>();

            if(category != null)
            {
                housesToShow = housesToShow
                    .Where(h => h.Category.Name == category);
            }

            if(searchTerm != null)
            {
                string normalizedSearcTerm = searchTerm.ToLower();
                housesToShow = housesToShow
                    .Where(h => (h.Title.ToLower().Contains(normalizedSearcTerm)
                        || h.Address.ToLower().Contains(normalizedSearcTerm) 
                        || h.Description.ToLower().Contains(normalizedSearcTerm)));
            }

            housesToShow = sorting switch
            { 
                HouseSorting.Price => housesToShow
                    .OrderBy(h => h.PricePerMonth),
                HouseSorting.NotRentedFirst => housesToShow
                    .OrderBy(h => h.RenterId == null)
                    .ThenByDescending(h => h.Id),
                _ => housesToShow
                    .OrderByDescending(h => h.Id),
            };

            var houses = await housesToShow
                .Skip((curentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .Select(h => new HouseServiceModel()
                {
                    Id = h.Id,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                    IsRented = h.RenterId != null,
                    PricePerMonth = h.PricePerMonth,
                    Title = h.Title,
                })
                .ToListAsync();

            int totalHouses = await housesToShow.CountAsync();

            return new HouseQueryServiceModel()
            {
                Houses = houses,
                TotalHousesCount = totalHouses
            };
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await repozitory.AllReadOnly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> CreateAsync(HouseFormModel model, int agentId)
        {
            House house = new House()
            {
                Address = model.Address,
                AgentId = agentId,
                CategoryId = model.CategoryId,
                PricePerMonth = model.PricePerMonth,
                Title = model.Title,
            };

            await repozitory.AddAsync(house);
            await repozitory.SaveChangesAsync();

            return house.Id;
        }

        public async Task<IEnumerable<HouseIndexServiceModel>> LastThreeHousesAsync()
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
