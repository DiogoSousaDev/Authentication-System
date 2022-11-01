using LoginSystem.Identidade.API.Configurations;

// ======================================== BUILDER ========================================
var builder = WebApplication.CreateBuilder(args);

// Adicionar suporte a diversos arquivos de configuração por ambiente.
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();


builder.AddIdentityConfiguration();
builder.AddApiConfiguration();
builder.AddSwaggerConfiguration();

// ======================================== APP ========================================
var app = builder.Build();
app.UseSwaggerConfiguration();
app.UseApiConfiguration();



