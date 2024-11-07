using Microsoft.EntityFrameworkCore;
using PromotionService.ApplicationCore.Repositories;
using PromotionService.Infrastructure.Data;
using PromotionService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PromotionDbContext>(option => {

    option.UseSqlServer(builder.Configuration.GetConnectionString("PromotionDb"));



    //option.UseSqlServer(Environment.GetEnvironmentVariable("OrderDb"));

});

builder.Services.AddScoped<IPromotionSalesRepositoryAsync, PromotionSalesRepositoryAsync>();
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
