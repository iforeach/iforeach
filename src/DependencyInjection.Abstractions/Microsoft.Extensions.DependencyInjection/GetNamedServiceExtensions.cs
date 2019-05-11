using System;
using System.Collections.Generic;
using System.Linq;

using org.iForeach.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static partial class ServicesExtensions
    {
        #region Get Named Service

        /// <summary>
        /// 获取命名服务
        /// </summary>
        /// <param name="name">服务名称</param>
        public static object GetService(this IServiceProvider provider, string name) =>
            provider.GetService(NamedType.Get(name));

        /// <summary>
        /// 获取命名服务
        /// </summary>
        /// <param name="name">服务名称</param>
        public static object GetRequiredService(this IServiceProvider provider, string name) =>
            provider.GetRequiredService(NamedType.Get(name));

        /// <summary>
        /// 获取命名服务
        /// </summary>
        /// <param name="name">服务名称</param>
        public static object GetRequiredService(this IServiceProvider provider, string name, Type serviceType) =>
            provider.GetRequiredService(NamedType.Get(name, serviceType));

        /// <summary>
        /// 获取命名服务
        /// </summary>
        /// <param name="name">服务名称</param>
        public static T GetRequiredService<T>(this IServiceProvider provider, string name) =>
            (T)provider.GetRequiredService(NamedType.Get(name, typeof(T)));

        /// <summary>
        /// 获取命名服务
        /// </summary>
        /// <param name="name">服务名称</param>
        public static T GetService<T>(this IServiceProvider provider, string name) =>
            (T)provider.GetService(NamedType.Get(name, typeof(T)));

        /// <summary>
        /// 获取命名服务
        /// </summary>
        /// <param name="name">服务名称</param>
        public static IEnumerable<T> GetServices<T>(this IServiceProvider provider, string name) =>
            provider.GetServices(NamedType.Get(name, typeof(T))).OfType<T>().ToArray();

        /// <summary>
        /// 获取命名服务
        /// </summary>
        /// <param name="name">服务名称</param>
        public static IEnumerable<object> GetServices(this IServiceProvider provider, string name, Type serviceType) =>
            provider.GetServices(NamedType.Get(name, serviceType)).Where(serviceType.IsInstanceOfType).ToArray();

        #endregion
    }
}
