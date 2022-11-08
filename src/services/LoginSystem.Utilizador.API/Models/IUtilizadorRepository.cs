using LoginSystem.Core.Data;

namespace LoginSystem.Utilizador.API.Models
{
    public interface IUtilizadorRepository : IRepository<Models.Utilizador>
    {
        void Adicionar(Utilizador utilizador);
        Task<IEnumerable<Utilizador>> ObterTodos();
        Task<Utilizador> ObterPorNif(string nif);
    }
}
