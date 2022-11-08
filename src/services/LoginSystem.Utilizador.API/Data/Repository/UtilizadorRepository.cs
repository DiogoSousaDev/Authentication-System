using LoginSystem.Core.Data;
using LoginSystem.Utilizador.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginSystem.Utilizador.API.Data.Repository
{
    public class UtilizadorRepository : IUtilizadorRepository
    {
        private readonly ClienteDbContext _clienteDbContext;

        public UtilizadorRepository(ClienteDbContext clienteDbContext)
        {
            _clienteDbContext = clienteDbContext;
        }

        public IUnitOfWork UnitOfWork => _clienteDbContext;

        public void Adicionar(Models.Utilizador utilizador)
        {
            _clienteDbContext.Utilizadores.Add(utilizador);
        }


        public async Task<Models.Utilizador> ObterPorNif(string nif)
        {
            return await _clienteDbContext.Utilizadores.FirstOrDefaultAsync(u => u.NIF.Numero == nif);
        }

        public async Task<IEnumerable<Models.Utilizador>> ObterTodos()
        {
            return await _clienteDbContext.Utilizadores.AsNoTracking().ToListAsync();
        }

        public void Dispose()
        {
            _clienteDbContext.Dispose();
        }
    }
}
