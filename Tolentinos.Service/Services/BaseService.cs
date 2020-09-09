using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Tolentinos.Domain.Entities;
using Tolentinos.Domain.Interfaces;
using Tolentinos.Infra.Data.Repository;

namespace Tolentinos.Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {

        protected readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual T Post<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            _repository.Insert(obj);
            return obj;
        }

        public virtual T Put<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            _repository.Update(obj);
            return obj;
        }

        public virtual void Remove(long id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser zero.");

            _repository.Remove(id);
        }

        public virtual IList<T> Get(params string[] includes) => includes != null && includes.Any() ? _repository.SelectAll(includes) : _repository.SelectAll();

        public virtual T Get(long id, params string[] includes)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser zero.");

            return includes != null && includes.Any() ? _repository.Select(id, includes) : _repository.Select(id);
        }

        public virtual IList<T> GetWhere(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            return includes != null && includes.Any() ? _repository.SelectWhere(predicate, includes) : _repository.SelectWhere(predicate);
        }

        protected void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }

    }
}
