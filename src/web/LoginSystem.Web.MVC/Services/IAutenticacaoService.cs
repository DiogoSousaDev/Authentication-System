using LoginSystem.Web.MVC.Extensions;
using LoginSystem.Web.MVC.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace LoginSystem.Web.MVC.Services
{
    public interface IAutenticacaoService
    {
        Task<UtilizadorRespostaLogin> Login(UtilizadorLogin utilizadorLogin);
        Task<UtilizadorRespostaLogin> Registo(UtilizadorRegisto utilizadorRegisto);
    }

    public class AutenticacaoService : Service, IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient,
                                   IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.AutenticacaoUrl);
            _httpClient = httpClient;
        }

        public async Task<UtilizadorRespostaLogin> Login(UtilizadorLogin utilizadorLogin)
        {
            var content = ObterConteudo(utilizadorLogin);

            var response = await _httpClient.PostAsync("/api/identidade/autenticar", content);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            if (!TratarErrosResponse(response))
            {
                return new UtilizadorRespostaLogin
                {
                    ResponseResult = JsonSerializer.Deserialize<ResponseResult>(await response.Content.ReadAsStringAsync(), options)
                };
            }

            return JsonSerializer.Deserialize<UtilizadorRespostaLogin>(await response.Content.ReadAsStringAsync(), options);
        }

        public async Task<UtilizadorRespostaLogin> Registo(UtilizadorRegisto utilizadorRegisto)
        {
            var content = ObterConteudo(utilizadorRegisto);
            var response = await _httpClient.PostAsync("/api/identidade/nova-conta", content);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            if (!TratarErrosResponse(response))
            {
                return new UtilizadorRespostaLogin
                {
                    ResponseResult = JsonSerializer.Deserialize<ResponseResult>(await response.Content.ReadAsStringAsync(), options)
                };
            }

            return JsonSerializer.Deserialize<UtilizadorRespostaLogin>(await response.Content.ReadAsStringAsync(), options);
        }
    }
}
