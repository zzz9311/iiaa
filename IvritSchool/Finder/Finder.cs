using IvritSchool.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IvritSchool.Finder
{
    public class Finder<TEntity> : IFinder<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;
        public Finder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity Find(object key)
        {
            return _dbContext.Set<TEntity>().Find(key);
        }
    }
}
