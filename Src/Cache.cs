using System.Collections.Generic;

namespace Zoo
{
    public class Cache<TKey, TValue>
    {
        private readonly Dictionary<TKey, CacheItem<TValue>> _cache = new Dictionary<TKey, CacheItem<TValue>>();

        public void Store(TKey key, TValue value)
        {
            _cache[key] = new CacheItem<TValue>(value);
        }

        public TValue Get(TKey key)
        {
            if (!_cache.ContainsKey(key)) return default;
            var cached = _cache[key];
            return cached.Value;
        }
    }

    public class CacheItem<T>
    {
        public CacheItem(T value)
        {
            Value = value;
        }
        public T Value { get; }
    }
}
