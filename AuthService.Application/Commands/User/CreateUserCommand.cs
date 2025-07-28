using MediatR;

namespace AuthService.Application.Commands
{
  public record CreateUserCommand(
    string Name,
    string Password,
    string Email,
    string DadFirstName,
    string MomFirstName,
    string DadLastName,
    string MomLastName,
    DateTime BirthDay,
    string Ci
    ) : IRequest<Guid>;
}