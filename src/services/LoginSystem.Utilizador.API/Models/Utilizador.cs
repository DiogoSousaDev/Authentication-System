using LoginSystem.Core.DomainObjects;

namespace LoginSystem.Utilizador.API.Models
{
    public class Utilizador : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public Nif NIF { get; private set; }
        public bool Excluido { get; private set; }
        public Morada Morada { get; private set; }

        // EF Relation
        protected Utilizador() { }

        public Utilizador(Guid id, string nome, string email, string nif)
        {
            Id = id;
            Nome = nome;
            Email = new Email(email);
            NIF = new Nif(nif);
            Excluido = false;
        }

        public void TrocarEmail(string email)
        {
            Email = new Email(email);
        }

        public void AtribuirMorada(Morada morada)
        {
            Morada = morada;
        }
    }
}
