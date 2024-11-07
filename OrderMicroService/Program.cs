using Microsoft.EntityFrameworkCore;
using OrderMicroservice.ApplicationCore.Repositories;
using OrderMicroService.Infrastructure.Data;
using OrderMicroService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OrderDbContext>(option => {

    option.UseSqlServer(builder.Configuration.GetConnectionString("OrderDb"));



    //option.UseSqlServer(Environment.GetEnvironmentVariable("OrderDb"));

});

builder.Services.AddScoped<IOrderRepositoryAsync, OrderRepositoryAsync>();
builder.Services.AddScoped<ICustomerRepositoryAsync, CustomerRepositoryAsync>();
builder.Services.AddScoped<IPaymentTypeRepositoryAsync, PaymentTypeRepositoryAsync>();
builder.Services.AddScoped<IShoppingCartRepositoryAsync, ShoppingCartRepositoryAsync>();

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
