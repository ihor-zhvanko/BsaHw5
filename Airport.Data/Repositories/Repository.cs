using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using Airport.Common.Exceptions;

using Airport.Data.MockData;
using Airport.Data.Models;


namespace Airport.Data.Repositories
{
  public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
  {
    private DbContext _dbContext;
    public Repository(DbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
    {
      if (filter != null)
        return _dbContext.Set<TEntity>().Where(filter);

      return _dbContext.Set<TEntity>();
    }

    public virtual TEntity Create(TEntity entity, string createdBy = null)
    {
      _dbContext.Set<TEntity>().Add(entity);
      return entity;
    }

    public virtual TEntity Update(TEntity entity, string modifiedBy = null)
    {
      _dbContext.Update(entity);
      return entity;
    }

    public virtual void Delete(TEntity entity)
    {
      _dbContext.Set<TEntity>().Remove(entity);
    }

    public virtual void Delete(int id)
    {
      var entity = _dbContext.Set<TEntity>().Where(x => x.Id == id);
      _dbContext.RemoveRange(entity);
    }

    public virtual TEntity Get(int id)
    {
      var result = _dbContext.Set<TEntity>().FirstOrDefault(x => x.Id == id);
      if (result == null)
        throw new NotFoundException(typeof(TEntity).Name + " with such id was not found");
      return result;
    }

    public abstract IEnumerable<TEntity> Details(Expression<Func<TEntity, bool>> filter = null);
  }
}