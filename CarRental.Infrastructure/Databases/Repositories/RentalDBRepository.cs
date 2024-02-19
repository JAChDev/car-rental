using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Domain.Responses;
using CarRental.Infrastructure.Databases.RentalDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Infrastructure.Databases.Repositories
{
    public class RentalDBRepository:IRentalDBRepository, IDisposable
    {
        private readonly AppDBContext _context;
        public RentalDBRepository(AppDBContext context)
        {
            _context = context;
        }

        public HashSet<Car> GetCarsDb(string city, string department)
        {
            try
            {
                HashSet<Car> cars = _context.Cars.Where(v => v.MarketOrigin == city + " - " + department && v.Avaliable == true).ToHashSet();
                return cars;
            }
            catch
            {
                return new HashSet<Car>();
            }
            finally
            {
                Dispose();
            }
        }

        public AddRentalResponse AddRental(Rental rental)
        {
            try
            {
                _context.Rentals.Add(rental);
                var Car = _context.Cars.FirstOrDefault(v => v.Id == rental.CarId);
                if (Car != null)
                {
                    Car.Avaliable = false;
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("No existe el vehículo especificado");
                }
                return new AddRentalResponse { Id=rental.Id, Success = true, Message = $"Renta registrada exitosamente" };
            }
            catch (Exception ex)
            {
                return new AddRentalResponse { Success = false, Message = $"Error al registrar solicitud, Excepción: {ex.Message}" };
            }
            finally
            {
                Dispose();
            }
        }


        public Rental? GetRentalById(Guid id)
        {
            try
            {
                var rental = _context.Rentals.FirstOrDefault(v => v.Id == id);
                return rental;
            }
            catch
            {
                return new Rental();
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
