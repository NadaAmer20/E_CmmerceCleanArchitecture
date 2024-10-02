using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using E_Commerce.Core;
using E_Commerce.Core.Middleware;
using E_Commerce.Infrastructure;
using E_Commerce.Infrustructure.Context;
using E_Commerce.Service;
using System.Globalization;
using System.Text.Json.Serialization;
using E_Commerce.Infrustructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
          .AddJsonOptions(options =>
          {
              options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
              options.JsonSerializerOptions.WriteIndented = true;
          });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"));
});

builder.Services.AddInfrastructureDependencies().AddServiceDependendcies()
    .AddCoreDependencies().AddServiceRegisteration(builder.Configuration);
#region Depenendcy Injection
builder.Services.AddInfrastructureDependencies().AddServiceDependendcies();
#endregion

#region Localization 
builder.Services.AddControllersWithViews();
builder.Services.AddLocalization(opt =>
{
    opt.ResourcesPath = "";
});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    List<CultureInfo> supportedCultures = new List<CultureInfo>
        {
                new CultureInfo("en-US"),
                new CultureInfo("de-DE"),
                new CultureInfo("fr-FR"),
                new CultureInfo("ar-EG")
        };

    options.DefaultRequestCulture = new RequestCulture("ar-EG");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

#endregion
#region Cors
var Cors = "_cors";
builder.Services.AddCors(options =>
  options.AddPolicy(name: Cors, builder =>

  {
      builder.AllowAnyHeader();
      builder.AllowAnyMethod();
      builder.AllowAnyOrigin();
  }
      )
);
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
#region Localization Middleware
var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);
#endregion
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseCors(Cors);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
