using FluentValidation.Results;
using LoginSystem.Core.Data;

namespace LoginSystem.Core.Messages
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        public CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        public void AdicionarErro(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected async Task<ValidationResult> PersistirDados(IUnitOfWork unitOfWork)
        {
            if (!await unitOfWork.Commit()) AdicionarErro("Ocorreu um erro ao adicionar o utilizador no banco de dados");

            return ValidationResult;
        }
    }
}
