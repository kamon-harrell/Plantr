using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Plantr.Models
{
    public class Plant
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; internal set; }
    }
}