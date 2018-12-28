using System;
using System.Runtime.Caching;
using V2EX.Client.Utils;

namespace V2EX.Client.Helpers
{
    public static class MemoryCacheHelper
    {
        private static readonly MemoryCache Cache = MemoryCache.Default;

        private static readonly AsyncConsumerQueue<CacheEntryRemovedArguments> Consumer =
            new AsyncConsumerQueue<CacheEntryRemovedArguments>(DisposeCacheItem);

        static MemoryCacheHelper()
        {
            Consumer.Start();
        }

        public static bool TryGet<T>(string key , out T value)
        {
            Predication.CheckNotNull(key);
            if (Cache.Contains(key) && Cache.Get(key) is T cacheItem)
            {
                value = cacheItem;
                return true;
            }

            value = default(T);
            return false;
        }

        public static void Add(string key, object value)
        {
            Predication.CheckNotNull(value);
            Predication.CheckNotNull(key);
            var policy = new CacheItemPolicy
            {
                // TODO : TEST
                SlidingExpiration = new TimeSpan(0, 0, 0, 1)
            };

            policy.RemovedCallback += Consumer.Enqueue;
            Cache.Add(key, value, policy);
        }

        private static void DisposeCacheItem(CacheEntryRemovedArguments args)
        {
            if(args.CacheItem.Value is IDisposable disposable)
                disposable.Dispose();
            Console.WriteLine("Dispose");
        }
    }
}
