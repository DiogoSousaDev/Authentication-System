using LoginSystem.Utilizador.API.Data;
using Microsoft.EntityFrameworkCore;

namespace LoginSystem.Utilizador.API.Configurations
{
    public static class ApiConfig
    {
        public static void AddApiConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ClienteDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();
        }

        public static void UseApiConfiguration(this WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
