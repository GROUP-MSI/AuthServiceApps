using AuthService.Domain.Entities;
using FluentResults;
using MediatR;

namespace AuthService.Application.Commands
{
  public record CreateUserCommand(
    string Name,
    string Password,
    string Email,
    int AppId
    ) : IRequest<Result<int>>;
}