using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Entities
{
    public class Car
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string MarketOrigin { get; set; }
        [Required]
        public string MarketLocation { get; set; }
        [Required]
        public bool Avaliable { get; set; }

    }
}
