using System.Linq.Expressions;

namespace AuthService.Domain.Repositories
{
  public interface IBaseRepository
  {
    Task<List<T>> GetAll<T>() where T : class;
    Task<T> GetById<T>(int id) where T : class;
    Task<T> Create<T>(T entity) where T : class;
    Task Update<T>(T entity) where T : class;
    Task Remove<T>(T entity) where T : class;
    IQueryable<T> GetQueryable<T>() where T : class;
    Task<T> FindByConditionAsync<T>(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default) where T : class;
  }
}