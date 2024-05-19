using System.Linq.Expressions;
using System.Net.Sockets;
using Microsoft.EntityFrameworkCore;
using MPTWA_Domain;
using MPTWA_Infrastructure.Models.Requests;
using MPTWA_Infrastructure.Models.Responses;

namespace MPTWA_Application.Interfaces;

public interface IRepository<TContext> where TContext : DbContext
{
    IQueryable<TContext> Get<TContext>(Expression<Func<TContext, bool>> selector) where TContext : BaseEntity;
    Task<TContext?> GetLastAsync<TContext>() where TContext : BaseEntity;
    Task AddAsync<TContext>(TContext entity) where TContext : BaseEntity;
    Task AddRangeAsync<TContext>(params TContext[] entity) where TContext : BaseEntity;
    Task<int> SaveChangesAsync();
}