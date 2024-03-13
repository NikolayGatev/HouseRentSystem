using System.ComponentModel.DataAnnotations;
using static HouseRentSystem.Common.DataLocalConstants.Category;

namespace HouseRentSystem.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Houses = new List<House>();
        }

        [Key]

        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLegnthName)]

        public string Name { get; set; } = string.Empty;

        public ICollection<House> Houses { get; set; } = null!;
    }
}
