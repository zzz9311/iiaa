using System;
using System.Linq.Expressions;

namespace IvritSchool.Repository
{
    public interface IIncludable<TEntity, TType>
    {
        TType Include<TProperty>(Expression<Func<TEntity, TProperty>> includeProperty);
        TType Include<TProperty>(Expression<Func<TEntity, TProperty[]>> includeProperty);
    }
}
