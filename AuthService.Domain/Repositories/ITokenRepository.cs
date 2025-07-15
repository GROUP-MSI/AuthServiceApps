using AuthService.Domain.Entities;

namespace AuthService.Domain.Repositories
{
  public interface ITokenRepositoy
  {
    Task<TokenEntity> CreateToken(TokenEntity token, int userId, int timeValidMin);
    Task<TokenEntity> GetTokenRefresh(string refreshToken, string token, int idUser);
    Task DesactiveToken(int userId);
    Task DropToken(int id);
  }
}