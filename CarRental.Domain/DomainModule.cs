using Autofac;
using CarRental.Domain.Interfaces;
using CarRental.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain
{
    public class DomainModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RentalCarServices>().As<IRentalCarServices>().InstancePerLifetimeScope();
        }
    }
}
