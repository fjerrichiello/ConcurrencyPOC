using ConcurrencyPOC.Persistence;
using Microsoft.EntityFrameworkCore;
using ConcurrencyPOC.Configuration;
using ConcurrencyPOC.DTOs;
using ConcurrencyPOC.Endpoints;
using ConcurrencyPOC.Handlers;
using ConcurrencyPOC.Persistence.Repositories;
using ConcurrencyPOC.Persistence.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add Services
services.AddScoped<IAddBookHandler, AddBookHandler>();


services.AddScoped<IBookRepository, BookRepository>();

services.AddScoped<IBookRequestRepository, BookRequestRepository>();

services.AddScoped<IUnitOfWork, UnitOfWork<ApplicationDbContext>>();

services.AddScoped<IBookCountRepository, BookCountRepository>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConcurrencyDatabase")));

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.ConfigureHttpJsonOptions();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.MapBookEndpoints();

app.Run();