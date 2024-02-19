using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Domain.Responses;
using CarRental.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.DTOs;
using AutoMapper;

namespace CarRental.Domain.Services
{
    public class RentalCarServices : IRentalCarServices
    {
        private readonly IRentalDBRepository _dbRepository;
        private readonly IMapper _mapper;


        public RentalCarServices(IRentalDBRepository dBRepository, IMapper mapper)
        {
            _dbRepository = dBRepository;
            _mapper = mapper;
        }

        public AddRentalResponse AddRental(RentalDto rentalDto)
        {
            try
            {
                rentalDto.Id = Guid.NewGuid();
                Rental rental = _mapper.Map<Rental>(rentalDto);
                AddRentalResponse addRental = _dbRepository.AddRental(rental);
                return addRental;
            }
            catch (Exception ex)
            {
                return new AddRentalResponse { Success=false,Message=ex.Message};
            }
        }

        public GetCarsResponse GetNearbtCars(string dirIn, string dirOut )
        {
            try
            {
                string[] addressDelivery = dirIn.Split(" - ");
                string[] addressReception = dirOut.Split(" - ");
                HashSet<Car> cars = _dbRepository.GetCarsDb(addressDelivery[0], addressDelivery[1]);

                if (cars == null || cars.Count == 0)
                {
                    
                    throw new CarNotFoundException("No se encontraron vehículos disponibles");
                };
                HashSet<CarDto> carDtos = new HashSet<CarDto>(cars.Select(car => _mapper.Map<CarDto>(car)));
                GetCarsResponse response = new GetCarsResponse
                {
                    status = true,
                    taxes = addressDelivery[1] != addressReception[1] ? "10%" : addressDelivery[0] != addressReception[0] ? "5%" : "0",
                    Cars = carDtos,
                    message = "Se encontraron vehículos disponibles"
                };

                return response;
            }
            catch (CarNotFoundException ex)
            {
                GetCarsResponse empty = new()
                {
                    status = false,
                    message = ex.Message
                };
                return empty;
            }
            catch (Exception ex)
            {
                GetCarsResponse error = new()
                {
                    status = false,
                    message = ex.Message
                };
                return error;
            }
        }

        public GetRentalTransactionResponse GetRentalById(string id)
        {
            try
            {
                Rental? rental = _dbRepository.GetRentalById(Guid.Parse(id));
                RentalDto rentalDto = _mapper.Map<RentalDto>(rental);
                return rental != null ? new GetRentalTransactionResponse { Status = true, Data = rentalDto }
                                      : new GetRentalTransactionResponse { Status = false };
            }
            catch
            {
                return new GetRentalTransactionResponse { Status = false };
            }

        }
    }
}
