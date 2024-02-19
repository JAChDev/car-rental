using CarRental.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Responses
{
    public class GetRentalTransactionResponse
    {
        public bool Status {get;set;}
        public RentalDto? Data {get;set;}
    }
}
