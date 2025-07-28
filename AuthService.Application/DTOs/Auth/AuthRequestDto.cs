namespace AuthService.Application.DTOs
{
  public record AuthRequestDto(string NameOrGmail, string Password);
  
  public record AuthRefreshTokenRequestDto(string TokenExpired, string RefreshToken);
}