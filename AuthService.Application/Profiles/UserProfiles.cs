using AuthService.Application.Commands;
using AuthService.Application.DTOs;
using AuthService.Domain.Entities;
using AutoMapper;

namespace AuthService.Application.Profiles
{
  public class UserProfiles : Profile
  {
    public UserProfiles()
    {
      CreateMap<RegisterUserRequestDto, CreateUserCommand>();
      CreateMap<CreateUserCommand, UserEntity>();
      CreateMap<CreateUserCommand, UserInfoEntity>();
      CreateMap<UserEntity, UserDetailDto>();
      CreateMap<UserDetailDto, UserEntity>();
      CreateMap<AuthResponseDto, TokenEntity>()
      .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));

    }
  }
}