using CarDealershipAPI.Core.Abstractions;
using CarDealershipAPI.Core.Mappers;
using CarDealershipAPI.Core.Services;
using CarDealershipAPI.Data;
using CarDealershipAPI.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICarCategoryRepository, CarCategoryRepository>();
builder.Services.AddScoped<ICarTypeRepository, CarTypeRepository>();
builder.Services.AddScoped<ICarCategoryService, CarCategoryService>();
builder.Services.AddScoped<ICarTypeService, CarTypeService>();
builder.Services.AddScoped<ICarCategoryMapper, CarCategoryMapper>();
builder.Services.AddScoped<ICarTypeMapper, CarTypeMapper>();

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
