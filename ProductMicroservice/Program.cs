using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Repositories;
using ProductMicroservice.Infrastructure.Data;
using ProductMicroservice.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProductDbContext>(option => {

    option.UseSqlServer(builder.Configuration.GetConnectionString("ProductDb"));



    //option.UseSqlServer(Environment.GetEnvironmentVariable("OrderDb"));

});

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryVariationRepository, CategoryVariationRepository>();
builder.Services.AddScoped<IProductVariationRepository, ProductVariationRepository>();
builder.Services.AddScoped<IVariationValueRepository, VariationValueRepository>();

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
