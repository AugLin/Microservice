using Microsoft.EntityFrameworkCore;
using ReviewMicroservice.ApplicationCore.Repositories;
using ReviewMicroservice.Infrastructure.Data;
using ReviewMicroservice.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ReviewDbContext>(option => {

    option.UseSqlServer(builder.Configuration.GetConnectionString("ReviewDb"));



    //option.UseSqlServer(Environment.GetEnvironmentVariable("OrderDb"));

});

builder.Services.AddScoped<ICustomerRepositoryAsync, CustomerRepositoryAsync>();
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
