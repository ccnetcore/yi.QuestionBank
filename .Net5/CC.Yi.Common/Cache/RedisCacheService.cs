using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace CC.Yi.Common.Cache
{
    public class RedisCacheService :ICacheWriter
    {
        private RedisCache _redisCache = null;
        public RedisCacheService(RedisCacheOptions options)
        {
            _redisCache = new RedisCache(options);
        }
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <returns></returns>
        public string Get(string key)
        {
            try
            {
                if (!string.IsNullOrEmpty(key))
                {
                    return Encoding.UTF8.GetString(_redisCache.Get(key));
                }
                else
                {
                    return string.Empty;
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <param name="value">缓存值</param>
        /// <param name="ExpirationTime">绝对过期时间(分钟)</param>
        public void Add(string key, string value, int ExpirationTime = 20)
        {
            if (!string.IsNullOrEmpty(key))
            {
                _redisCache.Set(key, Encoding.UTF8.GetBytes(value), new DistributedCacheEntryOptions()
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(ExpirationTime)
                });
            }
        }

        public void AddString(string key, string value)
        {
            _redisCache.SetString(key, value);
        }

        public string GetString(string key)

        {
            return _redisCache.GetString(key);
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">缓存key</param>
        public void Remove(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                _redisCache.Remove(key);
            }
        }
        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <param name="value">缓存值</param>
        /// <param name="ExpirationTime"></param>
        public void Replace(string key, string value, int ExpirationTime = 20)
        {
            if (!string.IsNullOrEmpty(key))
            {
                _redisCache.Remove(key);
                _redisCache.Set(key, Encoding.UTF8.GetBytes(value), new DistributedCacheEntryOptions()
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(ExpirationTime)
                });
            }
        }
    }
}
