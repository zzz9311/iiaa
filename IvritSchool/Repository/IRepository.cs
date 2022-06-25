using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IvritSchool.Repository
{
    public interface IRepository<TEntity>
    {
        public void Insert(TEntity entity);
        public void Delete(TEntity entity);
        public TEntity Find(Func<TEntity, bool> predicate);
        public TEntity[] ToArray(Func<TEntity, bool> predicate);
        public TEntity[] ToArray();
        public IRepository<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> includeProperty);
        public IRepository<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty[]>> includeProperty);
    }
}
