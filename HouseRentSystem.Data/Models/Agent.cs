using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HouseRentSystem.Common.DataLocalConstants.Agent;

namespace HouseRentSystem.Data.Models
{
    public class Agent
    {
        public Agent()
        {
            this.Houses = new List<House>();
        }

        [Key]

        public int Id { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLegnth)]

        public string PhoneNumber { get; set; } = null!;

        [Required]

        public string UserId { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(UserId))]

        public IdentityUser User { get; set; } = null!;

        public IList<House> Houses { get; set; } = null!;
    }
}