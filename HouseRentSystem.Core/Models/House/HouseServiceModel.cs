using System.ComponentModel.DataAnnotations;
using static HouseRentSystem.Common.MassageConstants;
using static HouseRentSystem.Common.DataLocalConstants.House;

namespace HouseRentSystem.Core.Models.House
{
    public class HouseServiceModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TitleMaxLegnth, MinimumLength = TitleMinLegnth
            ,ErrorMessage = LengthMessage)]

        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(AddressMaxLegnth, MinimumLength = AddressMinLegnth
            ,ErrorMessage = LengthMessage)]

        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Image URL")]

        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal)
            ,PricePerMonthMinLegnth, PricePerMonthMaxLegnth,
            ConvertValueInInvariantCulture = true)]
        [Display(Name = "Price per month")]

        public decimal PricePerMonth { get; set; }

        [Display(Name = "Is Rented")]

        public bool IsRented { get; set; }
    }
}