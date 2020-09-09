using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Tolentinos.Domain.Entities;

namespace Tolentinos.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T obj);

        void Update(T obj);

        void Remove(long id);

        T Select(long id);
        
        T Select(long id, params string[] includes);

        IList<T> SelectAll();

        IList<T> SelectAll(params string[] includes);

        IList<T> SelectWhere(Expression<Func<T, bool>> predicate);
        
        IList<T> SelectWhere(Expression<Func<T, bool>> predicate, params string[] includes);

        IQueryable<T> GetQueryable(params string[] includes);

    }
}
