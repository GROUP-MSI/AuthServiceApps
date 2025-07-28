using AuthService.Application.DTOs;

namespace AuthService.Application.Services.Interfaces
{
  public interface IAuthService
  {
    Task<AuthResponseDto> Login(AuthRequestDto request);
    Task<AuthResponseDto> RefreshToken(int idUser);
    Task<AuthResponseDto> RegisterUser(RegisterUserRequestDto register);
    Task<bool> ValidateRefreshToken(AuthRefreshTokenRequestDto auth, int idUser);
  }
}