using Microsoft.OpenApi.Models;

namespace LoginSystem.Identidade.API.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API - Identidade",
                    Description = "Esta API tem como objetivo fazer o registo e autenticação de utilizadores",
                    Contact = new OpenApiContact() { Name = "Diogo Sousa", Email = "diogoapsousadev@gmail.com" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
                });
            });
        }

        public static void UseSwaggerConfiguration(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
