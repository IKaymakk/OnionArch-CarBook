using CarBook.Application.Features.Handlers.AboutHandlers;
using CarBook.Application.Features.Handlers.BannerHandlers;
using CarBook.Application.Features.Handlers.BrandHandlers;
using CarBook.Application.Features.Handlers.CarHandlers;
using CarBook.Application.ServiceRegistration;
using CarBook.Application.Features.Handlers.CategoryHandlers;
using CarBook.Application.Inferfaces;
using CarBook.Persistance.Repositories;
using Persistance.Context;
using Domain.Entities;
using FluentValidation.AspNetCore;
using System.Reflection;
using CarBook.WebApi.ServiceRegistration;
using CarBook.WebApi.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddApiApplicationServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<CarHub>("/carhub");
app.Run();
