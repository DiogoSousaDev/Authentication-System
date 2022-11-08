using MediatR;

namespace LoginSystem.Utilizador.API.Application.Events
{
    public class UtilizadorEventHandler : INotificationHandler<UtilizadorRegistadoEvent>
    {
        public Task Handle(UtilizadorRegistadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
