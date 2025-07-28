using AuthService.Application.Commands;
using AuthService.Application.DTOs;

namespace AuthService.Application.Services.Interfaces
{
  public interface IUserService
  {
    CreateUserCommand MapToCommand(RegisterUserRequest request);
  }
}