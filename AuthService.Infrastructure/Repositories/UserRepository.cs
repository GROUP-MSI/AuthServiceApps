using AuthService.Application.Helpers;
using AuthService.Domain.Entities;
using AuthService.Domain.Repositories;
using AuthService.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly DataContext _context;
    public UserRepository(DataContext context)
    {
      _context = context;
    }

    public async Task<UserEntity> GetUserByAuth(string nameOrGmail, string password)
    {
      var user = await _context.Users
        .Where(u => u.Name == nameOrGmail || u.Email == nameOrGmail)
        .FirstOrDefaultAsync();

      if (user == null) return null;

      if (!PasswordHashSecurity.VerifyPassword(user.Password, password, user.PasswordSalt)) return null;

      return user;
    }


    public async Task<UserEntity> GetUserAuthById(int id) =>
      await _context.Users
        .AsNoTracking()
        .FirstOrDefaultAsync(u => u.Id == id);


    public async Task CreateUser(UserEntity create, Guid salt)
    {
      create.PasswordSalt = salt;

      await _context.Users.AddAsync(create);
      await _context.SaveChangesAsync();
    }

    public async Task<UserEntity> GetUserByName(string name) =>
      await _context.Users
        .Where(u => u.Name == name)
        .FirstOrDefaultAsync();

    public async Task<UserEntity> GetUserByEmail(string email) =>
      await _context.Users
        .Where(u => u.Email == email)
        .FirstOrDefaultAsync();
  }
}