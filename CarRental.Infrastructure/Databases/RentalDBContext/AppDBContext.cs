using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Infrastructure.Databases.RentalDBContext
{
    public class AppDBContext:DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public void LoadCarsDataFromCSV()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "CarRental.Infrastructure", "DataFiles", "CarData.csv");

            var cars = ReadCarsFromCSV(filePath);

            if (cars != null)
            {
                Cars.AddRange(cars);
                SaveChanges();
            }
        }

        private IEnumerable<Car> ReadCarsFromCSV(string filePath)
        {
            var lines = File.ReadAllLines(filePath).Skip(1);

            foreach (var line in lines)
            {
                var fields = line.Split(';');
                var car = new Car
                {
                    Id = fields[0],
                    Brand = fields[1],
                    Model = fields[2],
                    MarketOrigin = fields[3],
                    MarketLocation = fields[4],
                    Avaliable = bool.Parse(fields[5])
                };

                yield return car;
            }
        }

    }
}
