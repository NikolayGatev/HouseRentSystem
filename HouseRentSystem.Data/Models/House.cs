using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Cache;
using static HouseRentSystem.Common.DataLocalConstants.House;

namespace HouseRentSystem.Data.Models
{
    public class House
    {
        [Key]

        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLegnth)]

        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(AddressMaxLegnth)]

        public string Address { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLegnth)]

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerMonth { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]

        public Category Category { get; set; } = null!;

        public int AgentId { get; set; }

        [Required]
        [ForeignKey(nameof(AgentId))]

        public Agent Agent { get; set; } = null!;

        public string? RenterId { get; set; }
    }
}