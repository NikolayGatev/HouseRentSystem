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
                    .Where(h => h.Title.ToLower().Contains(normalizedSearcTerm)
                        || h.Address.ToLower().Contains(normalizedSearcTerm) 
                        || h.Description.ToLower().Contains(normalizedSearcTerm));
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
                .ProjectToHouseServiceModel()
                //.Select(h => new HouseServiceModel()
                //{
                //    Id = h.Id,
                //    Address = h.Address,
                //    ImageUrl = h.ImageUrl,
                //    IsRented = h.RenterId != null,
                //    PricePerMonth = h.PricePerMonth,
                //    Title = h.Title,
                //})
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
                Description = model.Description,
                CategoryId = model.CategoryId,
                ImageUrl = model.ImageUrl,
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
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                    Title = h.Title,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<HouseServiceModel>> AllHousesByAgentIdAsync(int agentId)
        {
            return await repozitory.AllReadOnly<House>()
                .Where(h => h.AgentId == agentId)
                .ProjectToHouseServiceModel()
                .ToListAsync();
        }

        public async Task<IEnumerable<HouseServiceModel>> AllHousesByUserId(string userId)
        {
            return await repozitory.AllReadOnly<House>()
                .Where(h => h.RenterId == userId)
                .ProjectToHouseServiceModel()
                .ToListAsync();
        }

        public async Task<bool> ExistAsync(int Id)
        {
            return await repozitory.AllReadOnly<House>()
                .AnyAsync(h => h.Id == Id);
        }

        public async Task<HouseDetailsServiceModel> HouseDetailsByIdAsync(int id)
        {
            return await repozitory.AllReadOnly<House>()
                .Where(h => h.Id == id)
                .Select(h => new HouseDetailsServiceModel()
                {
                    Id = h.Id,
                    Address = h.Address,
                    Agent = new Models.Agent.AgentServiceModel()
                    {
                        Email = h.Agent.User.Email,
                        PhoneNumber = h.Agent.PhoneNumber,
                    },
                    Category = h.Category.Name,
                    Description = h.Description,
                    ImageUrl = h.ImageUrl,
                    IsRented = h.RenterId != null,
                    PricePerMonth = h.PricePerMonth,
                    Title = h.Title,
                })
                .FirstAsync();
        }

        public async Task EditAsync(int houseId, HouseFormModel model)
        {
            var house = await repozitory.GetByIdAsync<House>(houseId);

            if (house != null)
            {
                house.Address = model.Address;
                house.CategoryId = model.CategoryId;
                house.Description = model.Description;
                house.ImageUrl = model.ImageUrl;
                house.PricePerMonth = model.PricePerMonth;
                house.Title = model.Title;

                await repozitory.SaveChangesAsync();
            }
        }

        public async Task<bool> HasAgentWithIdAsync(int houseId, string userId)
        {
            return await repozitory.AllReadOnly<House>()
                .AnyAsync(h => h.Id == houseId
                            && h.Agent.UserId == userId);
        }

        public async Task<HouseFormModel?> GetHouseFormByIdAsync(int id)
        {
            var house = await repozitory.AllReadOnly<House>()
                .Where(h => h.Id == id)
                .Select(h => new HouseFormModel()
                {
                    Address = h.Address,
                    CategoryId = h.CategoryId,
                    Description = h.Description,
                    ImageUrl = h.ImageUrl,
                    PricePerMonth = h.PricePerMonth,
                    Title = h.Title,
                })
                .FirstOrDefaultAsync();
            if(house != null)
            {
                house.Categories = await AllCategoriesAsync();
            }

            return house;
        }

        public async Task<HouseDetailsViewModel?> GetHouseDetailsFormByIdAsync(int id)
        {
            var house = await repozitory.All<House>()
                .Where(h => h.Id == id)
                .Select(h => new HouseDetailsViewModel()
                {
                    Id = h.Id,
                    Title = h.Title,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                })
                .FirstOrDefaultAsync();

            return house;
        }

        public async Task DeleteAsync(int id)
        {
            await repozitory.DeleteAsync<House>(id);
            await repozitory.SaveChangesAsync();
        }

        public async Task<bool> IsRentedAsync(int id)
        {
            var house = await repozitory.GetByIdAsync<House>(id);

            var result = house?.RenterId != null ? true : false;

            return result;
        }

        public async Task<bool> IsRentedByUserWhitIdAsync(int houseId, string userId)
        {
            var house = await repozitory.GetByIdAsync<House>(houseId);

            var result = house == null || house.RenterId != userId ? false : true;

            return result;
        }

        public async Task Rent(int houseId, string userId)
        {
            var house = await repozitory.GetByIdAsync<House>(houseId);

            if(house != null)
            {
                house.RenterId = userId;
                await repozitory.SaveChangesAsync();
            }
        }

        public async Task LeaveAsync(int houseId, string userId)
        {
            House? house = await repozitory.GetByIdAsync<House>(houseId);

            if (house != null)
            {
                if(house.RenterId != userId)
                {
                    throw new UnauthorizedAccessException("The user is not the renter!");
                }

                house.RenterId = null;
                await repozitory.SaveChangesAsync();  
            }
        }
    }
}
