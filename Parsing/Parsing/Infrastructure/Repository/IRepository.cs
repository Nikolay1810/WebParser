using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parsing.Infrastructure.Repository
{
    public interface IRepository<TEntity>:IDisposable where TEntity:class
    {
        TEntity FindById(int id);
        IEnumerable<TEntity> Get();
        TEntity AddEntity(TEntity entity);

        TEntity Get(Func<TEntity, bool> predicate);

        bool AddEntityRange(List<TEntity> entity);
        bool UpdateEntity(TEntity entity);
    }
}