using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

using Api.RoutingConventions;
using Domain.Factories;
using Domain.Interfaces.Factories;
using Domain.Interfaces.Services;
using Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddScoped<IBoxFactory, BoxFactory>();
builder.Services.AddScoped<IPackageService, PackageService>();

builder.Services.AddControllers(options =>
{
    // Adiciona prefixo "v1" para todas as rotas
    options.Conventions.Insert(0, new RoutePrefixConvention(new AttributeRouteModel(new RouteAttribute("v1"))));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
