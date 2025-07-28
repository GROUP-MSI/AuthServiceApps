using AuthService.Application.Commands;
using AuthService.Application.DTOs;
using AutoMapper;

namespace AuthService.Application.Profiles
{
  public class UserProfiles : Profile
  {
    public UserProfiles()
    {
      CreateMap<RegisterUserRequest, CreateUserCommand>();
    }
  }
}