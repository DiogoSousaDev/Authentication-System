using LoginSystem.Web.MVC.Extensions;
using LoginSystem.Web.MVC.Services;

namespace LoginSystem.Web.MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<IUser, AspNetUser>();
          
        }
    }
}
