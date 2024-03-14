using System.ComponentModel.DataAnnotations;
using static HouseRentSystem.Common.MassageConstants;
using static HouseRentSystem.Common.DataLocalConstants.Agent;


namespace HouseRentSystem.Core.Models.Agent
{
    public class BecomeAgentFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PhoneNumberMaxLegnth, MinimumLength = PhoneNumberMinLegnth,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Phone number")]
        [Phone]

        public string PhoneNumber { get; set; } = null!;
    }
}
