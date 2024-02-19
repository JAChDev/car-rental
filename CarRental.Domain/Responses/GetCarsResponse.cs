using CarRental.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Responses
{
    public class GetCarsResponse
    {
        public bool status { get; set; }
        public string taxes { get; set; }
        public HashSet<CarDto> Cars { get; set; }
        public string message { get; set; }

    }
}
