using System;
using System.Collections.Generic;
using System.Linq;

using org.iForeach.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static partial class ServicesExtensions
    {
        #region Get Keyed Service

        /// <summary>
        /// 获取命名服务
        /// </summary>
        /// <param key="key">服务名称</param>
        public static object GetService(this IServiceProvider provider, object key) =>
            provider.GetService(KeyedType.Get(key));

        /// <summary>
        /// 获取命名服务
        /// </summary>
        /// <param key="key">服务名称</param>
        public static object GetRequiredService(this IServiceProvider provider, object key) =>
            provider.GetRequiredService(KeyedType.Get(key));

        /// <summary>
        /// 获取命名服务
        /// </summary>
        /// <param key="key">服务名称</param>
        public static object GetRequiredService(this IServiceProvider provider, object key, Type serviceType) =>
            provider.GetRequiredService(KeyedType.Get(key, serviceType));

        /// <summary>
        /// 获取命名服务
        /// </summary>
        /// <param key="key">服务名称</param>
        public static T GetRequiredService<T>(this IServiceProvider provider, object key) =>
            (T)provider.GetRequiredService(KeyedType.Get(key, typeof(T)));

        /// <summary>
        /// 获取命名服务
        /// </summary>
        /// <param key="key">服务名称</param>
        public static T GetService<T>(this IServiceProvider provider, object key) =>
            (T)provider.GetService(KeyedType.Get(key, typeof(T)));

        /// <summary>
        /// 获取命名服务
        /// </summary>
        /// <param key="key">服务名称</param>
        public static IEnumerable<T> GetServices<T>(this IServiceProvider provider, object key) =>
            provider.GetServices(KeyedType.Get(key, typeof(T))).OfType<T>().ToArray();

        /// <summary>
        /// 获取命名服务
        /// </summary>
        /// <param key="key">服务名称</param>
        public static IEnumerable<object> GetServices(this IServiceProvider provider, object key, Type serviceType) =>
            provider.GetServices(KeyedType.Get(key, serviceType)).Where(serviceType.IsInstanceOfType).ToArray();

        #endregion
    }
}
