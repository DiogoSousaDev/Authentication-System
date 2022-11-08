using FluentValidation.Results;
using LoginSystem.Core.Messages;

namespace LoginSystem.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<ValidationResult> EnviarCommando<T>(T comando) where T : Command;
    }
}
