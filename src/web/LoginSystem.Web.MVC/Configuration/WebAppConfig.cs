using LoginSystem.Web.MVC.Extensions;

namespace LoginSystem.Web.MVC.Configuration
{
    public static class WebAppConfig
    {
        public static void AddWebAppConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews();
            builder.Services.Configure<AppSettings>(builder.Configuration);
        }

        public static void UseWebAppConfiguration(this WebApplication app)
        {
            //// Configure the HTTP request pipeline.
            //if (!app.Environment.IsDevelopment())
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            app.UseExceptionHandler("/erro/500");
            app.UseStatusCodePagesWithRedirects("/erro/{0}");
            app.UseHsts();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityConfiguration();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
