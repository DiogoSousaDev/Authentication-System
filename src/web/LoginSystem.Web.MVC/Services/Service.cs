using LoginSystem.Web.MVC.Models;
using System.Text.Json;
using System.Text;
using System.Reflection.Metadata;
using System.Security.Cryptography.Xml;
using LoginSystem.Web.MVC.Extensions;

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

        protected bool TratarErrosResponse(HttpResponseMessage response)
        {
            switch ((int) response.StatusCode)
            {
                case 401:
                case 403:
                case 404:
                case 500:
                    throw new CustomHttpRequestException(response.StatusCode);

                case 400:
                    return false;
            }

            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}
