using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Tolentinos.Infra.Data.Cache
{
    public class DistributedCacheHandler
    {

        private readonly IDistributedCache _cache;
        private DistributedCacheEntryOptions _options;

        public DistributedCacheHandler(IDistributedCache cache, DistributedCacheEntryOptions options)
        {
            _cache = cache;
            _options = options;
        }

        public IList<T> GetList<T>(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            IList<T> res = null;

            //Salvo os parametros da query como nome
            var json = _cache.GetString(this.GenerateKey<T>(predicate, includes));
            
            if (!string.IsNullOrEmpty(json))
            {
                res = JsonConvert.DeserializeObject<IList<T>>(json);
            }

            return res;
        }

        public IList<T> GetList<T>(string key)
        {
            IList<T> res = null;

            //Salvo os parametros da query como nome
            var json = _cache.GetString(key);

            if (!string.IsNullOrEmpty(json))
            {
                res = JsonConvert.DeserializeObject<IList<T>>(json);
            }

            return res;
        }

        public void SetList<T>(Expression<Func<T, bool>> predicate, IList<T> list, params string[] includes)
        {

            _cache.SetString(
                this.GenerateKey<T>(predicate, includes), 
                JsonConvert.SerializeObject(list, new JsonSerializerSettings() { 
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }), 
                _options);

        }

        public void SetList<T>(string key, IList<T> list)
        {
            _cache.SetString(
                key,
                JsonConvert.SerializeObject(list, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }),
                _options);
        }

        private string GenerateKey<T>(Expression<Func<T, bool>> predicate, params string[] includes) {
            return $"{typeof(T).FullName}-{predicate.Body}-includes:{string.Join(',', includes)}";
        }

    }
}
