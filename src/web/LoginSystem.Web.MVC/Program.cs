using LoginSystem.Web.MVC.Configuration;

// ===================================== BUILDER =====================================
var builder = WebApplication.CreateBuilder(args);
builder.AddIdentityConfiguration();
builder.AddWebAppConfiguration();
builder.RegisterServices();

// ===================================== APP =====================================
var app = builder.Build();
app.UseWebAppConfiguration();

