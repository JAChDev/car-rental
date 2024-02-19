using AutoMapper;
using CarRental.Domain.DTOs;
using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<Car, CarDto>();
            CreateMap<Rental, RentalDto>();
            CreateMap<RentalDto, Rental>();
        }
    }
}
