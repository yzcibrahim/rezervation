using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rezMvc.Models
{
    public class PlaceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Owner { get; set; }
        public string OwnerName { get; set; }

        public List<RezUserViewModel> Users { get; set; }
    }
}
