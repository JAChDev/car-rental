using CarRental.Domain.DTOs;
using CarRental.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Interfaces
{
    public interface IRentalCarServices
    {
        public GetCarsResponse GetNearbtCars(string dirIn, string dirOut);
        public AddRentalResponse AddRental(RentalDto rentalDto);
        public GetRentalTransactionResponse GetRentalById(string id);
    }
}

