using Loja_Manoel.Middlewares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

using Loja_Manoel.RoutingConventions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options =>
{
    // Adiciona prefixo "v1" para todas as rotas
    options.Conventions.Insert(0, new RoutePrefixConvention(new AttributeRouteModel(new RouteAttribute("v1"))));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware para redirecionar todas as URLs para seus equivalentes em minúsculas
app.UseLowercaseUrls();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
