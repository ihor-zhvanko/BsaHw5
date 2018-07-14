using System;
using System.Threading.Tasks;
using Airport.Data.MockData;
using Airport.Data.Repositories;
using Airport.Data.Models;

namespace Airport.Data.UnitOfWork
{
  public class UnitOfWork : IUnitOfWork
  {
    protected readonly DataSource _dataSource;

    public UnitOfWork(DataSource dataSource)
    {
      _dataSource = dataSource;
    }

    public int SaveChanges()
    {
      throw new NotImplementedException();
    }

    public Task<int> SaveChangesAsync()
    {
      throw new NotImplementedException();
    }

    public IRepository<TEntity> Set<TEntity>() where TEntity : Entity
    {
      return new Repository<TEntity>(_dataSource);
    }
  }
}