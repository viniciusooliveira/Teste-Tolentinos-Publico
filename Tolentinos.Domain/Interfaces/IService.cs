using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Tolentinos.Domain.Entities;

namespace Tolentinos.Domain.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        T Post<V>(T obj) where V : AbstractValidator<T>;

        T Put<V>(T obj) where V : AbstractValidator<T>;

        void Remove(long id);

        T Get(long id, params string[] includes);

        IList<T> Get(params string[] includes);

        IList<T> GetWhere(Expression<Func<T, bool>> predicate, params string[] includes);
    }
}
