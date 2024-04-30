using Microsoft.EntityFrameworkCore;
using ProductMicroserviceProject.Models;
using ProductMicroserviceProject.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ProductDbContext>(
    options => options.UseSqlite(
        builder.Configuration.GetConnectionString("ProductDatabase"))
);
builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
