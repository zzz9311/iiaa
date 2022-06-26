using IvritSchool.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IvritSchool.Repository
{
    public class Repository<TEntity> : Includable<TEntity, Repository<TEntity>>,
                                       IRepository<TEntity> where TEntity : class
    {
        public Repository(ApplicationDbContext dbContext) : base(dbContext)
        {
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
            return _query.Where(predicate).FirstOrDefault();
        }

        public TEntity[] ToArray(Func<TEntity, bool> predicate)
        {
            return _query.Where(predicate).ToArray();
        }

        public TEntity[] ToArray()
        {
            return _query.ToArray();
        }
    }
}
