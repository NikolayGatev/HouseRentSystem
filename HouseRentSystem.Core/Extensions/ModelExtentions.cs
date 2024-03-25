using HouseRentSystem.Core.Contracts;
using System.Text.RegularExpressions;

namespace HouseRentSystem.Core.Extensions
{
    public static class ModelExtentions
    {
        public static string GetInformation(this IHouseModel house)
        {
           string info = house.Title.Replace(" ", "-") + GetAddress(house.Address);

            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

            return info;

        }

        private static string GetAddress(string address)
        {
            address = string.Join("-", address.Split(" ").Take(3));

            return address;
        }
    }
}
