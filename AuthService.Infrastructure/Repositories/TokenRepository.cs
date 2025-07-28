using AuthService.Application.DTOs;
using AuthService.Domain.Entities;
using AuthService.Domain.Repositories;
using AuthService.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Repositories
{
  public class TokenRepository : ITokenRepository
  {
    private readonly DataContext _context;
    public TokenRepository(DataContext context)
    {
      _context = context;
    }

    public async Task<TokenEntity> CreateToken(TokenEntity token, int userId, int timeValidMin)
    {
      token.UserId = userId;
      token.CurrentTime = DateTime.UtcNow;
      token.ExpirateDate = DateTime.UtcNow.AddMinutes(timeValidMin);

      await _context.Tokens.AddAsync(token);
      await _context.SaveChangesAsync();

      return token;
    }

    public async Task<TokenEntity> GetTokenRefresh(string refreshToken, string token, int idUser)
    {
      var refresToken = await _context.Tokens
        .FirstOrDefaultAsync(r => r.RefreshToken == refreshToken && r.CurrentToken == token && r.UserId == idUser && r.Active == true);

      return refresToken;
    }

    public async Task DesactiveToken(int userId)
    {
      var token = await _context.Tokens
        .Where(t => t.UserId == userId)
        .OrderByDescending(t => t.CurrentTime)
        .FirstOrDefaultAsync();

      if (token != null)
      {
        token.Active = false;
        _context.Tokens.Update(token);

        await _context.SaveChangesAsync();
      }
    }

    public async Task DropToken(int id)
    {
      var token = await _context.Tokens.Where(t => t.Id == id).FirstOrDefaultAsync();

      _context.Tokens.Remove(token);
      await _context.SaveChangesAsync();
    }

  }
}