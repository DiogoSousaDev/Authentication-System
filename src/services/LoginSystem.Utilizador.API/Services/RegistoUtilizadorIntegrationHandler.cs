using EasyNetQ;
using FluentValidation.Results;
using LoginSystem.Core.Mediator;
using LoginSystem.Core.Messages.Integration;
using LoginSystem.Utilizador.API.Application.Commands;

namespace LoginSystem.Utilizador.API.Services
{
    public class RegistoUtilizadorIntegrationHandler : BackgroundService
    {
        private IBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public RegistoUtilizadorIntegrationHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _bus = RabbitHutch.CreateBus("host=localhost:5672");

            _bus.Rpc.RespondAsync<UtilizadorRegistradoIntegrationEvent, ResponseMessage>(async request =>
            new ResponseMessage(await RegistarUtilizador(request)));

            return Task.CompletedTask;
        }

        private async Task<ValidationResult> RegistarUtilizador(UtilizadorRegistradoIntegrationEvent message)
        {
            var utilizadorCommand = new RegistarUtilizadorCommand(message.Id, message.Nome, message.Email, message.Nif);
            ValidationResult sucesso;

            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
                sucesso = await mediator.EnviarCommando(utilizadorCommand);
            }

            return sucesso;
        }
    }
}
