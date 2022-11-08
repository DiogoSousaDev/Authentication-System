using FluentValidation.Results;
using LoginSystem.Core.Mediator;
using LoginSystem.Utilizador.API.Application.Commands;
using LoginSystem.Utilizador.API.Application.Events;
using LoginSystem.Utilizador.API.Data;
using LoginSystem.Utilizador.API.Data.Repository;
using LoginSystem.Utilizador.API.Models;
using MediatR;

namespace LoginSystem.Utilizador.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void ResgisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IMediatorHandler, MediatorHandler>();
            builder.Services.AddScoped<IRequestHandler<RegistarUtilizadorCommand, ValidationResult>, UtilizadorCommandHadler>();
            builder.Services.AddScoped<INotificationHandler<UtilizadorRegistadoEvent>, UtilizadorEventHandler>();

            // Utilizador
            builder.Services.AddScoped<IUtilizadorRepository, UtilizadorRepository>();
            builder.Services.AddScoped<ClienteDbContext>();
        }
    }
}
