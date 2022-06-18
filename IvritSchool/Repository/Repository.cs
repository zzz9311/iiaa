using IvritSchool.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IvritSchool.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbSet<TEntity> _set;
        public Repository(ApplicationDbContext dbContext)
        {
            _set = dbContext.Set<TEntity>();
        }

        public void Insert(TEntity entity)
        {
            _set.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _set.Remove(entity);
        }

        public TEntity Find(Func<TEntity, bool> predicate)
        {
            return _set.Where(predicate).FirstOrDefault();
        }

        public TEntity[] ToArray(Func<TEntity, bool> predicate)
        {
            return _set.Where(predicate).ToArray();
        }

        public TEntity[] ToArray()
        {
            return _set.ToArray();
        }

        public IRepository<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> includeProperty)
        {
            _set = (DbSet<TEntity>) _set.Include(includeProperty);
            return this;
        }
    }
}
