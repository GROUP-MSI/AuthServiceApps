using System.Reflection;
using AuthService.Application.Services;
using AuthService.Application.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Application
{
  public static class DependencyInyection
  {
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
      services.AddMediatR(typeof(DependencyInyection).Assembly);
      services.AddAutoMapper(Assembly.GetExecutingAssembly());
      return services;
    }

    public static void LoadServicesApplication(this IServiceCollection services)
    {
      services.AddScoped<IUserService, UserService>();
    }
  }
}
