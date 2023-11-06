using System;
using System.Collections.Generic;

public class FunctionCache<TKey, TResult>
{
    private Dictionary<TKey, CacheItem<TResult>> cache = new Dictionary<TKey, CacheItem<TResult>>();

    public delegate TResult Func<TKey, TResult>(TKey key);

    public class CacheItem<T>
    {
        public T Value { get; set; }
        public DateTime ExpirationTime { get; set; }
    }

    public TResult GetOrAdd(TKey key, Func<TKey, TResult> function, TimeSpan expirationTime)
    {
        if (cache.TryGetValue(key, out CacheItem<TResult> cacheItem) && cacheItem.ExpirationTime > DateTime.Now)
        {
            return cacheItem.Value;
        }

        TResult result = function(key);

        cache[key] = new CacheItem<TResult>
        {
            Value = result,
            ExpirationTime = DateTime.Now.Add(expirationTime)
        };

        return result;
    }
}

class Program
{
    static void Main()
    {
        FunctionCache<string, int> cache = new FunctionCache<string, int>();

        FunctionCache<string, int>.Func<string, int> squareFunction = (string key) =>
        {
            int num = int.Parse(key);
            return num * num;
        };

        int result1 = cache.GetOrAdd("5", squareFunction, TimeSpan.FromSeconds(2)); 
        int result2 = cache.GetOrAdd("5", squareFunction, TimeSpan.FromSeconds(2)); 

        Console.WriteLine($"Result 1: {result1}"); 
        Console.WriteLine($"Result 2: {result2}"); 
    }
}