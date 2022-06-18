using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IvritSchool.Finder
{
    public interface IFinder<TEntity>
    {
        public TEntity Find(object key);
    }
}
