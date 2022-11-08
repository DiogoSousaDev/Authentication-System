using LoginSystem.Core.DomainObjects;

namespace LoginSystem.Utilizador.API.Models
{
    public class Morada : Entity
    {
        public string Rua { get; private set; }
        public string CP { get; private set; }
        public string Porta { get; private set; }
        public Guid UtilizadorId { get; private set; }

        // EF Relation
        public Utilizador Utilizador { get; private set; }

        public Morada(string rua, string cP, string porta)
        {
            Rua = rua;
            CP = cP;
            Porta = porta;
        }
    }
}
