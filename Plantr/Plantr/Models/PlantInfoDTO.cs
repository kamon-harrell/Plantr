using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plantr.Models
{
    public class PlantInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PlantName { get; set; }
    }
}