using HouseRentSystem.Core.Contracts;
using System.ComponentModel.DataAnnotations;
using static HouseRentSystem.Common.DataLocalConstants.House;
using static HouseRentSystem.Common.MassageConstants;

namespace HouseRentSystem.Core.Models.House
{
    public class HouseFormModel : IHouseModel
    {
        public HouseFormModel()
        {
            this.Categories = new HashSet<HouseCategoryServiceModel>();
        }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TitleMaxLegnth, MinimumLength = TitleMinLegnth
            ,ErrorMessage = LengthMessage)]

        public string Title { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(AddressMaxLegnth, MinimumLength = AddressMinLegnth
            , ErrorMessage = LengthMessage)]

        public string Address { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(DescriptionMaxLegnth, MinimumLength = DeskriptionMinLegnth
            , ErrorMessage = LengthMessage)]

        public string Description { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Image URL")]

        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal), PricePerMonthMinLegnth, PricePerMonthMaxLegnth
            , ErrorMessage = PriceValue)]
        [Display(Name = "Price Per Month")]

        public decimal PricePerMonth { get; set; }

        [Display(Name = "Category")]

        public int CategoryId { get; set; }

        public  IEnumerable<HouseCategoryServiceModel> Categories { get; set; }
    }
}
