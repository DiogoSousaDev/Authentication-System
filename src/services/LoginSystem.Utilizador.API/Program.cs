using LoginSystem.Utilizador.API.Configurations;
using MediatR;
using System.Reflection;

// =================================== BUILDER ===================================
var builder = WebApplication.CreateBuilder(args);

// Adicionar suporte a diversos arquivos de configuração por ambiente.
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();


builder.AddApiConfiguration();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.ResgisterServices();
builder.AddSwaggerConfiguration();

// =================================== APP ===================================
var app = builder.Build();
app.UseSwaggerConfiguration();
app.UseApiConfiguration();


