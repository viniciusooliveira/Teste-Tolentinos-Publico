using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Tolentinos.Domain.Entities;
using Tolentinos.Domain.Interfaces;

namespace Tolentinos.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {

        protected readonly Tolentinos.Infra.Data.Context.TolentinosContext _context;

        public BaseRepository(Tolentinos.Infra.Data.Context.TolentinosContext context)
        {
            _context = context;
        }


        public void Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(long id)
        {
            _context.Set<T>().Remove(Select(id));
            _context.SaveChanges();
        }

        public IList<T> SelectAll()
        {
            return _context.Set<T>().ToList();
        }

        public IList<T> SelectAll(params string[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
            return query.ToList();
        }

        public IList<T> SelectWhere(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public IList<T> SelectWhere(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
            return query.Where(predicate).ToList();
        }

        public IQueryable<T> GetQueryable(params string[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }

        public T Select(long id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Select(long id, params string[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
            return query.FirstOrDefault(o => o.Id == id);
        }

    }
}
