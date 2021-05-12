using Autofac;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CC.Yi.Common.Cache
{
    public class CacheHelper
    {
        public static ICacheWriter CacheWriter { get; set; }
        static CacheHelper()
        {
            //这里存在一些问题
            ContainerBuilder containerBuilder = new ContainerBuilder();
            IContainer container = containerBuilder.Build();
            CacheHelper.CacheWriter = container.Resolve<ICacheWriter>();
        }

        public static void AddCache(string key, string value, int expDate)
        {
            CacheWriter.Add(key, value, expDate);
        }

        //没有过期参数，表示用不过期
        public static void AddCache(string key, string value)
        {
            CacheWriter.Add(key, value);
        }

        public static object GetCache(string key)
        {
            return CacheWriter.Get(key);
        }
        public static void SetCache(string key, string value, int expDate)
        {

            CacheWriter.Replace(key, value, expDate);
        }

        //没有过期参数，表示用不过期
        public static void SetCache(string key, string value)
        {
            CacheWriter.Replace(key, value);
        }

        public static void Remove(string key)
        {
            CacheWriter.Remove(key);
        }

    }
}
