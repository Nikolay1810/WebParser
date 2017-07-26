using Parsing.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parsing.Infrastructure
{
    public class WorkWithContext<TEntity> where TEntity:class
    {
        IRepository<TEntity> repository;
        public WorkWithContext()
        {
            repository = new ShopRepository<TEntity>(new ShopContext());
        }

        public WorkWithContext(IRepository<TEntity> repos)
        {
            repository = repos;
        }

        public bool AddEntities(List<TEntity> entityList)
        {
            return repository.AddEntityRange(entityList);
        }

        public TEntity AddEntity(TEntity entity)
        {
            return repository.AddEntity(entity);
        }

        public TEntity Get(Func<TEntity, bool> predicate)
        {
            return repository.Get(predicate);
        }
        public IEnumerable<TEntity> Get()
        {
            return repository.Get();
        }

        public TEntity FindById(int id)
        {
            return repository.FindById(id);
        }
        public bool UpdateEntity(TEntity entity)
        {
            return repository.UpdateEntity(entity);
        }
    }
}