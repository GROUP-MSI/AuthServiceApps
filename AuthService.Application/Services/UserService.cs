using AuthService.Application.Commands;
using AuthService.Application.DTOs;
using AuthService.Application.Services.Interfaces;
using AutoMapper;

namespace AuthService.Application.Services
{
  public class UserService : IUserService
  {
    private readonly IMapper _mapper;
    public UserService(IMapper mapper)
    {
      _mapper = mapper;
    }

    public CreateUserCommand MapToCommand(RegisterUserRequest request) => _mapper.Map<CreateUserCommand>(request);
  }
}