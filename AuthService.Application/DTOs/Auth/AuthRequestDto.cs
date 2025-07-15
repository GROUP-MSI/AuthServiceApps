namespace AuthService.Application.DTOs
{
  public class AuthRequestDto
  {
    public string NameOrGmail { get; set; }
    public string Password { get; set; }
  }
  public class AuthRefreshTokenRequestDto
  {
    public string TokenExpired {get; set;} 
    public string RefreshToken {get; set;} 
  }
}