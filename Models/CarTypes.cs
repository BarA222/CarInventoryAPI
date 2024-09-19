using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarInventoryAPI.Models
{
    public class CarTypes
    {
        [Key]
        public Guid Id { get; set; }

        public string CarType { get; set; }

        public int Quantity { get; set; }

        public IsElectric IsElectric { get; set; }
    }
}