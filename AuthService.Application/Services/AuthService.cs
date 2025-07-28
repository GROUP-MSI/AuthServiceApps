using AuthService.Application.DTOs;
using AuthService.Application.Helpers;
using AuthService.Application.Services.Interfaces;
using AuthService.Domain.Entities;
using AuthService.Domain.Repositories;
using AutoMapper;
using Microsoft.Extensions.Options;

namespace AuthService.Application.Services
{
  public class AuthService : IAuthService
  {
    private readonly IMapper _mapper;
    private readonly ITokenRepository _repo;
    private readonly IUserRepository _userRepo;
    private readonly IOptions<JwtSettings> _jwtConfig;
    private readonly IBaseRepository _trepo;
    public AuthService(IMapper mapper, IOptions<JwtSettings> jwtConfig, IBaseRepository trepo)
    {
      _mapper = mapper;
      _jwtConfig = jwtConfig;
      _trepo = trepo;
    }

    public async Task<AuthResponseDto> Authentication(UserEntity user)
    {
      var response = new AuthResponseDto();
      response.User = _mapper.Map<UserDetailDto>(user);


      response.CurrentToken = Jwt.GenerateToken(_jwtConfig.Value, response.User);
      response.RefreshToken = Jwt.GenerateRefreshToken();
      await _repo.DesactiveToken(user.Id);
      await _repo.CreateToken(_mapper.Map<TokenEntity>(response), user.Id, _jwtConfig.Value.TimeValidMin);
      return response;
    }
    public async Task<AuthResponseDto> Login(AuthRequestDto request)
    {
      var user = await _userRepo.GetUserByAuth(request.NameOrGmail, request.Password);
      if (user == null) return null;
      return await Authentication(user);
    }

    public async Task<AuthResponseDto> RefreshToken(int idUser)
    {
      var user = await _userRepo.GetUserAuthById(idUser);
      return await Authentication(user);
    }
    
    public async Task<AuthResponseDto> RegisterUser(AuthRegisterDto register)
    {
      Guid salt = Guid.NewGuid();
      register.Password = PasswordHashSecurity.HashPassword(register.Password, salt);
      var userCreate = _mapper.Map<UserEntity>(register);

      var userInfoCreate = _mapper.Map<UserInfoEntity>(register);
      var user = await _userRepo.CreateUser(userCreate, salt);

      userInfoCreate.Id = user.Id;
      await _trepo.Create(userInfoCreate);

      return await Authentication(user);
    }

    public async Task<bool> ValidateRefreshToken(AuthRefreshTokenRequestDto auth, int idUser)
    {
      var tokenValid = await _repo.GetTokenRefresh(auth.RefreshToken, auth.TokenExpired, idUser);
      if (tokenValid == null) return false;
      else return true;
    }

  }
}