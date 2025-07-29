using AuthService.Infrastructure.Database;
using AuthService.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AuthService.Infrastructure.Repositories
{
  public class BaseRepository : IBaseRepository
  {
    private readonly DataContext _context;
    public BaseRepository(DataContext context)
    {
      _context = context;
    }

    public async Task<List<T>> GetAll<T>() where T : class =>
      await _context.Set<T>().ToListAsync();

    public async Task<T> GetById<T>(int id) where T : class =>
      await _context.Set<T>().FindAsync(id);

    public async Task<T> Create<T>(T entity) where T : class
    {
      _context.Set<T>().Add(entity);
      await _context.SaveChangesAsync();
      return entity;
    }
    public async Task Update<T>(T entity) where T : class
    {
      _context.Set<T>().Update(entity);
      await _context.SaveChangesAsync();
    }

    public async Task Remove<T>(T entity) where T : class
    {
      _context.Set<T>().Remove(entity);
      await _context.SaveChangesAsync();
    }
    public IQueryable<T> GetQueryable<T>() where T : class =>
      _context.Set<T>();
      
    public async Task<T> FindByConditionAsync<T>(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default) where T : class =>
       await _context.Set<T>()
          .Where(expression)
          .FirstOrDefaultAsync(cancellationToken);
    
  }
}