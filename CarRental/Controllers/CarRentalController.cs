using AutoMapper;
using CarRental.Domain.DTOs;
using CarRental.Domain.Interfaces;
using CarRental.Domain.Responses;
using CarRental.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebApi.Controllers
{
    [Route("api/rental")]
    [ApiController]

    public class CarRentalController:ControllerBase
    {
        private readonly IRentalCarServices _rentalCarServices;
        private readonly IMapper _mapper;
        public CarRentalController(IRentalCarServices rentalCarServices, IMapper mapper)
        {
            _rentalCarServices = rentalCarServices;
            _mapper = mapper;
        }

        /// <summary>
        /// Servicio para consultar los vehículos disponibles en la zona y la tarifa de devolución si aplica
        /// </summary>
        /// <param name="dirIn" example="Bucaramanga - Santander">Dirección de recogida</param>
        /// <param name="dirOut" example="Cúcuta - Norte de Santander">Dirección de entrega</param>
        /// <returns></returns>
        [HttpGet]
        [Route("nearby-cars/{dirIn}&{dirOut}")]
        [ProducesResponseType(typeof(GetCarsResponse),200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult GetNearbyCars(string dirIn, string dirOut)
        {
            try
            {
                GetCarsResponse response = _rentalCarServices.GetNearbtCars(dirIn, dirOut);
                return response.status ? Ok(response):NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Servicio para efectuar transacción de renta
        /// </summary>
        /// <param name="rentalModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("rental-service")]
        public IActionResult AddService(RentalModel rentalModel)
        {
            try
            {
                RentalDto rentalDto = _mapper.Map<RentalDto>(rentalModel);
                AddRentalResponse response = _rentalCarServices.AddRental(rentalDto);
                return response.Success == true ? Ok(response) : BadRequest(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Servicio para transacción efectuada de renta por medio del Id de transacción
        /// </summary>
        /// <param name="id">Id de transacción</param>
        /// <returns></returns>
        [HttpGet]
        [Route("rental/{id}")]
        public IActionResult GetRentalById(string id)
        {
            try
            {
                GetRentalTransactionResponse response = _rentalCarServices.GetRentalById(id);
                return response.Status ? Ok(response.Data) : BadRequest("No se ha encontrado ninguna transacción con el id proporcionado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
