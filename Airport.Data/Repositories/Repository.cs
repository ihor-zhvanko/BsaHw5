using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Airport.Common.Exceptions;

using Airport.Data.MockData;
using Airport.Data.Models;

namespace Airport.Data.Repositories
{
  public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
  {
    protected DataSource _dataSource;
    public Repository(DataSource dataSource)
    {
      _dataSource = dataSource;
    }

    public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
    {
      if (filter != null)
        return _dataSource.Get<TEntity>().Where(filter.Compile());

      return _dataSource.Get<TEntity>();
    }

    protected int GenerateUniqueId()
    {
      var id = _dataSource.Get<TEntity>().OrderByDescending(x => x.Id).First().Id;

      return id + 1;
    }

    public virtual TEntity Create(TEntity entity, string createdBy = null)
    {
      entity.Id = GenerateUniqueId();
      _dataSource.Get<TEntity>().Add(entity);
      return entity;
    }

    public virtual TEntity Update(TEntity entity, string modifiedBy = null)
    {
      Delete(entity);
      _dataSource.Get<TEntity>().Add(entity);
      return entity;
    }

    public virtual void Delete(TEntity entity)
    {
      Delete(entity.Id);
    }

    public virtual void Delete(int id)
    {
      var toDelete = Get(id);

      _dataSource.Get<TEntity>().Remove(toDelete);
    }

    public virtual TEntity Get(int id)
    {
      var result = _dataSource.Get<TEntity>().FirstOrDefault(x => x.Id == id);
      if (result == null)
        throw new NotFoundException(typeof(TEntity).Name + " with such id was not found");
      return result;
    }
  }
}