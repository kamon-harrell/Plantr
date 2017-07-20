using System.ComponentModel.DataAnnotations;

namespace Plantr.Models
{
    public class PlantType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Catagory { get; set; }

        // Foreign Key
        public int PlantId { get; set; }
        // Navigation property
        public Plant Plant { get; set; }
    }
}