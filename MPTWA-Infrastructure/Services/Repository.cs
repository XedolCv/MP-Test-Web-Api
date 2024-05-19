using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MPTWA_Application.Interfaces;
using MPTWA_Domain;
using MPTWA_Domain.Entities;

namespace MPTWA_Infrastructure.Services;

public class Repository<TCon> :IRepository<TCon> where TCon:DbContext
{
    private readonly TCon _context;

    public Repository(TCon context)
    {
        _context = context;
    }

    public IQueryable<T> Get<T>(Expression<Func<T, bool>> selector) where T : BaseEntity
    {
        return _context.Set<T>().Where(selector).AsQueryable();
    }

    public async Task<T?> GetLastAsync<T>() where T : BaseEntity
    {
        return await _context.Set<T>().OrderBy(e=>e.CreateTime).AsQueryable().LastOrDefaultAsync();
    }

    public async Task AddAsync<T>(T entity) where T : BaseEntity =>
        await _context.Set<T>().AddAsync(entity);

    public async Task AddRangeAsync<T>(params T[] entity) where T : BaseEntity
    {
        await _context.Set<T>().AddRangeAsync(entity);
    }
    
    public async Task<int> SaveChangesAsync()
    {
      return await _context.SaveChangesAsync();
    }
}