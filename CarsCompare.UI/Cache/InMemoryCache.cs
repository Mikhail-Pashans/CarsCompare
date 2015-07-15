using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsCompare.UI.Cache
{
    public interface ICacheService
    {
        T Get<T>(string cacheId) where T : class;
        T Set<T>(string cacheId, T item, int expMinutes) where T : class;
        void Remove(string cacheId);
        void Remove(Func<KeyValuePair<string, object>, bool> predicate);
    }

    public class InMemoryCache : ICacheService
    {
        public T Get<T>(string cacheId) where T : class
        {
            var item = HttpRuntime.Cache.Get(cacheId) as T;
            return item;
        }

        public T Set<T>(string cacheId, T item, int expMinutes) where T : class
        {
            HttpRuntime.Cache.Insert(cacheId, item, null, DateTime.UtcNow.AddMinutes(expMinutes), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, null);
            return item;
        }

        public void Remove(string cacheId)
        {
            if (string.IsNullOrEmpty(cacheId))
            {
                IDictionaryEnumerator cacheEnum = HttpRuntime.Cache.GetEnumerator();

                while (cacheEnum.MoveNext())
                {
                    HttpRuntime.Cache.Remove(cacheEnum.Key.ToString());
                }
            }
            else
            {
                if (HttpRuntime.Cache[cacheId] != null)
                    HttpRuntime.Cache.Remove(cacheId);
            }
        }

        public void Remove(Func<KeyValuePair<string, object>, bool> predicate)
        {
            IDictionaryEnumerator cacheEnum = HttpRuntime.Cache.GetEnumerator();
            var collection = new Dictionary<string, object>();

            while (cacheEnum.MoveNext())
            {
                collection.Add(cacheEnum.Key.ToString(), HttpRuntime.Cache[cacheEnum.Key.ToString()]);
            }

            var filtered = collection.Where(predicate).ToList();

            if (!filtered.Any())
                return;

            foreach (var item in filtered)
            {
                HttpRuntime.Cache.Remove(item.Key);
            }
        }
    }
}