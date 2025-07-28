using MediatR;

namespace AuthService.WebApi.Configurations
{
  public static class ApplicationServiceExtensions
  {
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
      services.AddMediatR(typeof(ApplicationServiceExtensions).Assembly);
      return services;
    }
  }
}