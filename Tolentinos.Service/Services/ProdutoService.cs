using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Tolentinos.Domain.Entities;
using Tolentinos.Domain.Interfaces;
using Tolentinos.Infra.Data.Cache;
using Tolentinos.Infra.Data.Repository;
using Tolentinos.Helpers.Util.ExtensionMethods;

namespace Tolentinos.Service.Services
{
    public class ProdutoService : BaseService<Produto>
    {
        private readonly DistributedCacheHandler _cacheHandler;
        public ProdutoService(IRepository<Produto> repository, DistributedCacheHandler cacheHandler) : base(repository)
        {
            _cacheHandler = cacheHandler;
        }

        public override IList<Produto> GetWhere(Expression<Func<Produto, bool>> predicate, params string[] includes)
        {

            var cachedList = _cacheHandler.GetList<Produto>(predicate, includes);


            if(cachedList != null && cachedList.Any())
            {
                return cachedList;
            }

            var list = base.GetWhere(predicate, includes);

            _cacheHandler.SetList(predicate, list, includes);

            return list;
        }

        public IList<Produto> Get(int pagina, int quantidade, string query, long? idMarca, long? idCategoria, string ordem, bool descending, out long total)
        {
            var key = $"{typeof(Produto).FullName}-query={query}&idMarca={idMarca}&idCategoria={idCategoria}&ordem={ordem}&descending={descending}";

            var cachedList = _cacheHandler.GetList<Produto>(key);

            if (cachedList != null && cachedList.Any())
            {
                total = cachedList.Count;
                return cachedList.Skip((pagina-1)*quantidade).Take(quantidade).ToList();
            }

            var queryable = _repository.GetQueryable("Marca", "Categoria");

            if (!string.IsNullOrEmpty(query))
            {
                queryable = queryable.Where(m => m.Descricao.Contains(query) || m.Nome.Contains(query));
            }

            if (idMarca.HasValue)
            {
                queryable = queryable.Where(m => m.IdMarca == idMarca.Value);
            }

            if (idCategoria.HasValue)
            {
                queryable = queryable.Where(m => m.IdCategoria == idCategoria.Value);
            }

            if (!string.IsNullOrEmpty(ordem))
            {
                queryable = queryable.OrderBy(ordem, descending).AsQueryable();
            }


            var list = queryable.ToList();

            total = list.Count;

            _cacheHandler.SetList(key, list);

            return list.Skip((pagina - 1) * quantidade).Take(quantidade).ToList();
        }
    }
}
