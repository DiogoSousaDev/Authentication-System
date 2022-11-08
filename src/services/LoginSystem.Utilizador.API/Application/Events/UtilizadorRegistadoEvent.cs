using LoginSystem.Core.Messages;

namespace LoginSystem.Utilizador.API.Application.Events
{
    public class UtilizadorRegistadoEvent : Event
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Nif { get; private set; }

        public UtilizadorRegistadoEvent(Guid id, string nome, string email, string nif)
        {
            AggregateId = id;
            Id = id;
            Nome = nome;
            Email = email;
            Nif = nif;
        }
    }
}
