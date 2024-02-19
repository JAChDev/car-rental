using AutoMapper;
using CarRental.Domain.DTOs;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Domain.Responses;
using CarRental.Infrastructure.Databases.RentalDBContext;
using CarRental.Infrastructure.Databases.Repositories;
using CarRental.WebApi.Controllers;
using CarRental.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using Xunit;

namespace CarRental.Test
{
    public class CarRentalTest
    {
        private readonly Mock<IRentalCarServices> _mockRentalCarServices;
        private readonly Mock<IMapper> _mockMapper;

        public CarRentalTest()
        {
            _mockRentalCarServices = new Mock<IRentalCarServices>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public void GetNearbyCars_WithValidData_ReturnsOk()
        {
      
            var controller = new CarRentalController(_mockRentalCarServices.Object, _mockMapper.Object);
            var expectedResponse = new GetCarsResponse { status = true, taxes = "10", Cars = new HashSet<CarDto>{ new CarDto() } };
            _mockRentalCarServices.Setup(s => s.GetNearbtCars(It.IsAny<string>(), It.IsAny<string>())).Returns(expectedResponse);

            
            var result = controller.GetNearbyCars("Bucaramanga - Santander", "Cúcuta - Norte de Santander");

            
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<GetCarsResponse>(okResult.Value);
            Assert.True(model.status);
            Assert.Single(model.Cars);
        }

        [Fact]
        public void GetNearbyCars_WithInvalidData_ReturnsNoContent()
        {
            
            var controller = new CarRentalController(_mockRentalCarServices.Object, _mockMapper.Object);
            var expectedResponse = new GetCarsResponse { status = false };
            _mockRentalCarServices.Setup(s => s.GetNearbtCars(It.IsAny<string>(), It.IsAny<string>())).Returns(expectedResponse);

           
            var result = controller.GetNearbyCars("Invalid", "Data");

            
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void GetNearbyCars_ThrowsException_ReturnsBadRequest()
        {
            
            var controller = new CarRentalController(_mockRentalCarServices.Object, _mockMapper.Object);
            _mockRentalCarServices.Setup(s => s.GetNearbtCars(It.IsAny<string>(), It.IsAny<string>())).Throws<Exception>();

            
            var result = controller.GetNearbyCars("Exception", "Thrown");

           
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<string>(badRequestResult.Value);
        }

        [Fact]
        public void AddService_WithValidModel_ReturnsOk()
        {
           
            var controller = new CarRentalController(_mockRentalCarServices.Object, _mockMapper.Object);
            var rentalModel = new RentalModel();
            var rentalDto = new RentalDto();
            _mockMapper.Setup(m => m.Map<RentalDto>(It.IsAny<RentalModel>())).Returns(rentalDto);
            _mockRentalCarServices.Setup(s => s.AddRental(rentalDto)).Returns(new AddRentalResponse { Success = true });

          
            var result = controller.AddService(rentalModel);

           
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<AddRentalResponse>(okResult.Value);
            Assert.True(response.Success);
        }

        [Fact]
        public void AddService_WithNullRentalModel_ReturnsBadRequest()
        {
            var controller = new CarRentalController(_mockRentalCarServices.Object, _mockMapper.Object);
            RentalModel rentalModel = null;
            var result = controller.AddService(rentalModel);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void AddService_WithInvalidData_ReturnsBadRequest()
        {
            var controller = new CarRentalController(_mockRentalCarServices.Object, _mockMapper.Object);
            RentalModel invalidRentalModel = new RentalModel
            {
            };

            var result = controller.AddService(invalidRentalModel);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void GetRentalById_WithValidId_ReturnsOk()
        {
            var controller = new CarRentalController(_mockRentalCarServices.Object, _mockMapper.Object);
            var id = "validId";
            var expectedResponse = new GetRentalTransactionResponse { Status = true, Data = new RentalDto() };
            _mockRentalCarServices.Setup(s => s.GetRentalById(id)).Returns(expectedResponse);

            var result = controller.GetRentalById(id);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsAssignableFrom<RentalDto>(okResult.Value);
            Assert.NotNull(data);
        }

    }
}