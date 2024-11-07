using Microsoft.EntityFrameworkCore;
using ShippingMicroservice.ApplicationCore.Repositories;
using ShippingMicroservice.Infrastructure.Data;
using ShippingMicroservice.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ShipperDbContext>(option => {

    option.UseSqlServer(builder.Configuration.GetConnectionString("ShipperDb"));



    //option.UseSqlServer(Environment.GetEnvironmentVariable("OrderDb"));

});

builder.Services.AddScoped<IShipperRepositoryAsync, ShipperRepositoryAsync>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
