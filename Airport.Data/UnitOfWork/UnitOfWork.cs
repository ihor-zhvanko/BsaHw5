using System;
using System.Threading.Tasks;
using Airport.Data.MockData;
using Airport.Data.Repositories;
using Airport.Data.Models;

using Airport.Data.DatabaseContext;

namespace Airport.Data.UnitOfWork
{
  public class UnitOfWork : IUnitOfWork
  {
    protected readonly AirportDbContext _dbContext;

    public UnitOfWork(AirportDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public int SaveChanges()
    {
      return _dbContext.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
      return await _dbContext.SaveChangesAsync();
    }

    public IRepository<TEntity> Set<TEntity>() where TEntity : Entity
    {
      return new Repository<TEntity>(_dbContext);
    }
  }
}