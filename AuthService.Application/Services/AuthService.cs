using AuthService.Application.Commands;
using AuthService.Application.DTOs;
using AuthService.Application.Helpers;
using AuthService.Application.Services.Interfaces;
using AuthService.Domain.Entities;
using AuthService.Domain.Repositories;
using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.Extensions.Options;

namespace AuthService.Application.Services
{
  public class AuthService : IAuthService
  {
    private readonly IMapper _mapper;
    private readonly ITokenRepository _repo;
    private readonly IUserRepository _userRepo;
    private readonly IOptions<JwtSettings> _jwtConfig;
    private readonly IMediator _mediator;
    public AuthService(
      IMapper mapper,
      IOptions<JwtSettings> jwtConfig,
      IMediator mediator,
      ITokenRepository repo,
      IUserRepository userRepo)
    {
      _mapper = mapper;
      _jwtConfig = jwtConfig;
      _mediator = mediator;
      _repo = repo;
      _userRepo = userRepo;
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

    public async Task<Result<AuthResponseDto>> RegisterUser(RegisterUserRequestDto register)
    {
      var command = _mapper.Map<CreateUserCommand>(register);

      var result = await _mediator.Send(command);

      if (result.IsFailed)
        return Result.Fail<AuthResponseDto>(result.Errors);

      var user = await _userRepo.GetUserAuthById(result.Value);

      if (user == null)
        return Result.Fail<AuthResponseDto>("Usuario no encontrado después de creación");

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