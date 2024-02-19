using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.DTOs
{
    public class RentalDto
    {
        public Guid Id { get; set; }
        public string CarId { get; set; }
        public string Model { get; set; }
        public string PickUpMarket { get; set; }
        public string ReturnMarket { get; set; }
        public string PickUpAddress { get; set; }
        public string ReturnAddress { get; set; }
        public int ReturnTax { get; set; }
    }
}
