using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IvritSchool.Repository
{
    public interface IRepository<TEntity> : IIncludable<TEntity, Repository<TEntity>> where TEntity : class
    {
        public void Insert(TEntity entity);
        public void Insert(TEntity[] entities);
        public void Delete(TEntity entity);
        public TEntity Find(Func<TEntity, bool> predicate);
        public TEntity[] ToArray(Func<TEntity, bool> predicate);
        public TEntity[] ToArray();
    }
}
