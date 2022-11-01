namespace LoginSystem.Identidade.API.Configurations
{
    public static class ApiConfig
    {
        public static void AddApiConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
        }

        public static void UseApiConfiguration(this WebApplication app)
        {
            app.UseHttpsRedirection();

            app.UseIdentityConfiguration();

            app.MapControllers();

            app.Run();
        }
    }
}
