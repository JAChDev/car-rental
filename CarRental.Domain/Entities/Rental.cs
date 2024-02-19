using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Entities
{
    public class Rental
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string CarId { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string PickUpMarket { get; set; }
        [Required]
        public string ReturnMarket { get; set; }
        [Required]
        public string PickUpAddress { get; set; }
        [Required]
        public string ReturnAddress { get; set; }
        [Required]
        public int ReturnTax { get; set; }
    }
}
