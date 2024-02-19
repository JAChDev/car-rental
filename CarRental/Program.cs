using Autofac;
using AutoMapper;
using Autofac.Extensions.DependencyInjection;
using CarRental.Domain;
using CarRental.Infrastructure.Databases.RentalDBContext;
using Microsoft.EntityFrameworkCore;
using CarRental.Infrastructure;
using Microsoft.OpenApi.Models;
using CarRental.Domain.DTOs;
using CarRental.WebApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Car Rental API - V1",
            Version = "v1"
        }
     );

    var filePath = Path.Combine(System.AppContext.BaseDirectory, "CarRental.WebApi.xml");
    c.IncludeXmlComments(filePath);
});
builder.Services.AddDbContext<AppDBContext>(options =>
                        options.UseInMemoryDatabase("MilesCarRentalDatabase"));

using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();
    dbContext.LoadCarsDataFromCSV();
    dbContext.SaveChanges();
}

builder.Services.AddAutofac();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile<DomainProfile>();
    mc.CreateMap<RentalModel, RentalDto>();

});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => {
    builder.RegisterModule(new DomainModule());
    builder.RegisterModule(new InfrastructureModule());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
