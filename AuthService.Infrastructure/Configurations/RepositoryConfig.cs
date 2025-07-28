using AuthService.Domain.Repositories;
using AuthService.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Infrastructure.Configurations
{
  public static class RepositoryConfig
  {
    public static void LoadRepositories(this IServiceCollection services)
    {
      services.AddScoped<ITokenRepositoy, TokenRepository>();
      services.AddScoped<IBaseRepository, BaseRepository>();
      services.AddScoped<IUserRepository, UserRepository>();
    }
  }
}