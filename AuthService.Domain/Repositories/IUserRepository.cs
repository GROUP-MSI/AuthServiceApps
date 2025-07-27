using AuthService.Domain.Entities;

namespace AuthService.Domain.Repositories
{
  public interface IUserRepository
  {
    Task<UserEntity> GetUserByAuth(string nameOrGmail, string password);
    Task<UserEntity> GetUserAuthById(int id);
    Task<UserEntity> CreateUser(UserEntity create, Guid salt);
    Task<UserEntity> GetUserByName(string name);
    Task<UserEntity> GetUserByEmail(string email);
  }
}