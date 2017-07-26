using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Parsing.Infrastructure.Repository
{
    public class ShopRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        ShopContext context;
        DbSet<TEntity> dbSet;

        public ShopRepository(ShopContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public TEntity AddEntity(TEntity entity)
        {
            try
            {
                var addedEntity = dbSet.Add(entity);
                context.SaveChanges();
                return addedEntity;
            }
            catch(Exception ex)
            {
                return null;
            }
            return null;            
        }

        public bool AddEntityRange(List<TEntity> entity)
        {
            try
            {
                dbSet.AddRange(entity);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public TEntity FindById(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public TEntity Get(Func<TEntity, bool> predicate)
        {
            return dbSet.AsNoTracking().FirstOrDefault(predicate);
        }

        public bool UpdateEntity(TEntity entity)
        {
            try
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}