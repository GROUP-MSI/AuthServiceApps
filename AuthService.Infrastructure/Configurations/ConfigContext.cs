using AuthService.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Infrastructure.Configurations
{
  public static class ConfigContext
  {
    public static void ConfigureContext(this IServiceCollection services, string connectionString)
    {

      string connectionWorkDb = connectionString;

      services.AddDbContext<DataContext>(options =>
      {
        options.UseNpgsql(connectionWorkDb, sqlOptions =>
        {
          sqlOptions.CommandTimeout(60);
        });
      });

      services.AddDistributedMemoryCache();

      // services.AddSession(options =>
      // {
      //   options.IdleTimeout = TimeSpan.FromMinutes(30);
      //   options.Cookie.HttpOnly = true;
      //   options.Cookie.IsEssential = true;
      // });

      // services.Configure<RequestLocalizationOptions>(options =>
      // {
      //   options.DefaultRequestCulture = new RequestCulture("en-US");
      // });
    }
  }
}