using FluentValidation;
using LoginSystem.Core.Messages;

namespace LoginSystem.Utilizador.API.Application.Commands
{
    public class RegistarUtilizadorCommand : Command
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Nif { get; private set; }

        public RegistarUtilizadorCommand(Guid id, string nome, string email, string nif)
        {
            AggregateId = id;
            Id = id;
            Nome = nome;
            Email = email;
            Nif = nif;
        }

        public override bool EhValido()
        {
            ValidationResult = new RegistarUtilizadorValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class RegistarUtilizadorValidation : AbstractValidator<RegistarUtilizadorCommand>
        {
            public RegistarUtilizadorValidation()
            {
                RuleFor(c => c.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do utilizador inválido");

                RuleFor(c => c.Nome)
                   .NotEmpty()
                   .WithMessage("O nome do cliente não foi informado");

                RuleFor(c => c.Email)
                    .Must(TerEmailValido)
                    .WithMessage("O e-mail informado não é válido");

                RuleFor(c => c.Nif)
                   .Must(TerNifValido)
                   .WithMessage("O NIF informado não é válido");
            }

            public static bool TerEmailValido(string email)
            {
                return Core.DomainObjects.Email.Validar(email);
            }
            public static bool TerNifValido(string nif)
            {
                return Core.DomainObjects.Nif.Validar(nif);
            }
        }
    }
}
