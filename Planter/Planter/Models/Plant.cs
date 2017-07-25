using System.ComponentModel.DataAnnotations;

namespace Planter.Models
    {
    public class Plant
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public float Price { get; set; }
        public string Harvest { get; set; }
        public string Water { get; set; }
        public string Description { get; set; }
        public string Space { get; set; }
        public int Germination { get; set; }
    }
}