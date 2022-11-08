using LoginSystem.Core.Mediator;
using LoginSystem.Utilizador.API.Application.Commands;
using Microsoft.AspNetCore.Mvc;

namespace LoginSystem.Utilizador.API.Controllers
{
    public class UtilizadorController : MainController
    {

        private readonly IMediatorHandler _mediatorHandler;

        public UtilizadorController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("clientes")]
        public async Task<IActionResult> Index()
        {
            var resultado = await _mediatorHandler.EnviarCommando(
                new RegistarUtilizadorCommand(Guid.NewGuid(), "Diogo Sousa", "diogoapsousa@gmail.com", "220307751"));

            return CustomResponse(resultado);
        }
    }
}
