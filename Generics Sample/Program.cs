using Generics_Sample.Data;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//------------------------------------------------------------------------------------------------------------
builder.Services.AddMvc();
//------------------------------------------------------------------------------------------------------------
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnectionString")));
//------------------------------------------------------------------------------------------------------------
builder.Services.AddScoped<ApplicationDbContext>();
//------------------------------------------------------------------------------------------------------------
//Add Irepository Service
builder.Services.AddScoped(typeof(IRepository.IRepository<>),typeof(Repository<>));
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
