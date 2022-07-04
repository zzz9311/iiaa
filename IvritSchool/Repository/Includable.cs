using IvritSchool.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace IvritSchool.Repository
{
    public class Includable<TEntity, TType> : IIncludable<TEntity, TType>
                                              where TType : Includable<TEntity, TType>
                                              where TEntity : class
    {
        protected DbSet<TEntity> _set;
        protected IQueryable<TEntity> _query;
        public Includable(ApplicationDbContext dbContext)
        {
            _set = dbContext.Set<TEntity>();
            _query = dbContext.Set<TEntity>();
        }

        public TType Include<TProperty>(Expression<Func<TEntity, TProperty>> includeProperty)
        {
            _query = _query.Include(includeProperty);
            return (TType)this;
        }

        public TType Include<TProperty>(Expression<Func<TEntity, TProperty[]>> includeProperty)
        {
            _query = _query.Include(includeProperty);
            return (TType)this;
        }
    }
}
