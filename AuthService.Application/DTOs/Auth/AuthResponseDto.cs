namespace AuthService.Application.DTOs
{
  public class AuthResponseDto
  {
    public string CurrentToken {get; set;}
    public string RefreshToken { get; set; }
    public UserDetailDto User { get; set; }
  }
}