using CarRental.Domain.Entities;
using CarRental.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Interfaces
{
    public interface IRentalDBRepository
    {
        public HashSet<Car> GetCarsDb(string city, string department);
        public AddRentalResponse AddRental(Rental rental);
        public Rental? GetRentalById(Guid id);
    }
}
