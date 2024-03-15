namespace HouseRentSystem.Core.Models.House
{
    public class HouseQueryServiceModel
    {
        public HouseQueryServiceModel()
        {
            this.Houses = new HashSet<HouseServiceModel>();
        }

        public int TotalHousesCount { get; set; }

        public IEnumerable<HouseServiceModel> Houses { get; set; }
    }
}
