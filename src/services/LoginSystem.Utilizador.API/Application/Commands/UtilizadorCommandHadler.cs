using FluentValidation.Results;
using LoginSystem.Core.Messages;
using LoginSystem.Utilizador.API.Application.Events;
using LoginSystem.Utilizador.API.Models;
using MediatR;

namespace LoginSystem.Utilizador.API.Application.Commands
{
    public class UtilizadorCommandHadler : CommandHandler,
                                           IRequestHandler<RegistarUtilizadorCommand, ValidationResult>
    {
        private readonly IUtilizadorRepository _utilizadorRepository;

        public UtilizadorCommandHadler(IUtilizadorRepository utilizadorRepository)
        {
            _utilizadorRepository = utilizadorRepository;
        }

        public async Task<ValidationResult> Handle(RegistarUtilizadorCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var utilizador = new Models.Utilizador(message.Id, message.Nome, message.Email, message.Nif);

            var UtilizadorExiste = await _utilizadorRepository.ObterPorNif(utilizador.NIF.Numero);

            if (UtilizadorExiste != null)
            {
                AdicionarErro("Este NIF já está a ser utilizado");
                return ValidationResult;
            }

            _utilizadorRepository.Adicionar(utilizador);

            utilizador.AdicionarEvento(new UtilizadorRegistadoEvent(message.Id, message.Nome, message.Email, message.Nif));

            return await PersistirDados(_utilizadorRepository.UnitOfWork);
        }
    }
}
