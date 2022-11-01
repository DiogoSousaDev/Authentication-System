using LoginSystem.Web.MVC.Models;
using System.Text.Json;
using System.Text;

namespace LoginSystem.Web.MVC.Services
{
    public abstract class Service
    {
        protected StringContent ObterConteudo(object dado)
        {
            return new StringContent(
               JsonSerializer.Serialize(dado),
               Encoding.UTF8,
               "application/json"
               );
        }
    }
}
