using Autofac;
using CarRental.Domain.Interfaces;
using CarRental.Infrastructure.Databases.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Infrastructure
{
    public class InfrastructureModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RentalDBRepository>().As<IRentalDBRepository>();
        }
    }
}
