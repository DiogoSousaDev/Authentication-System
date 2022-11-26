namespace LoginSystem.Core.Messages.Integration
{
    public class UtilizadorRegistradoIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Nif { get; private set; }

        public UtilizadorRegistradoIntegrationEvent(Guid id, string nome, string email, string nif)
        {
            //  AggregateId = id;
            Id = id;
            Nome = nome;
            Email = email;
            Nif = nif;
        }
    }
}
