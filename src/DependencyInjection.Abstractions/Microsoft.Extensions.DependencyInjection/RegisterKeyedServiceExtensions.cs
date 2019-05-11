using System;

using org.iForeach.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 标识键服务扩展方法
    /// </summary>
    public static partial class ServicesExtensions
    {
        static Type GetKeyedType(this Type serviceType, object key)
            => KeyedType.Get(key, serviceType);

        #region Socped

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="services"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static IServiceCollection AddKeyedScoped<TService>(this IServiceCollection services, object key)
            where TService : class
            => services.AddScoped(typeof(TService).GetKeyedType(key), typeof(TService));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceType"></param>
        /// <param name="implementationType"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static IServiceCollection AddKeyedScoped(this IServiceCollection services, Type serviceType, object key, Type implementationType)
            => services.AddScoped(serviceType.GetKeyedType(key), implementationType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceType"></param>
        /// <param name="implementationFactory"></param>
        /// <returns></returns>
        public static IServiceCollection AddKeyedScoped(this IServiceCollection services, Type serviceType, object key, Func<IServiceProvider, object> implementationFactory)
            => services.AddScoped(serviceType.GetKeyedType(key), implementationFactory);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddKeyedScoped<TService, TImplementation>(this IServiceCollection services, object key)
            where TService : class
            where TImplementation : class, TService
               => services.AddScoped(typeof(TService).GetKeyedType(key), typeof(TImplementation));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public static IServiceCollection AddKeyedScoped(this IServiceCollection services, Type serviceType, object key)
            => services.AddScoped(serviceType.GetKeyedType(key), serviceType);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="services"></param>
        /// <param name="implementationFactory"></param>
        /// <returns></returns>
        public static IServiceCollection AddKeyedScoped<TService>(this IServiceCollection services, object key, Func<IServiceProvider, TService> implementationFactory)
            where TService : class
            => services.AddScoped(typeof(TService).GetKeyedType(key), sp => implementationFactory?.Invoke(sp) as object);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="services"></param>
        /// <param name="implementationFactory"></param>
        /// <returns></returns>
        public static IServiceCollection AddKeyedScoped<TService, TImplementation>(this IServiceCollection services, object key, Func<IServiceProvider, TImplementation> implementationFactory)
            where TService : class
            where TImplementation : class, TService
            => services.AddScoped(typeof(TService).GetKeyedType(key), sp => implementationFactory?.Invoke(sp) as object);

        #endregion

        #region Singleton

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="services"></param>
        /// <param name="key"></param>
        /// <param name="implementationFactory"></param>
        /// <returns></returns>
        public static IServiceCollection AddKeyedSingleton<TService, TImplementation>(this IServiceCollection services, object key, Func<IServiceProvider, TImplementation> implementationFactory)
            where TService : class
            where TImplementation : class, TService
            => services.AddSingleton(typeof(TService).GetKeyedType(key), sp => implementationFactory?.Invoke(sp) as object);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="services"></param>
        /// <param name="key"></param>
        /// <param name="implementationFactory"></param>
        /// <returns></returns>
        public static IServiceCollection AddKeyedSingleton<TService>(this IServiceCollection services, object key, Func<IServiceProvider, TService> implementationFactory)
            where TService : class
            => services.AddSingleton(typeof(TService).GetKeyedType(key), sp => implementationFactory?.Invoke(sp) as object);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="services"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static IServiceCollection AddKeyedSingleton<TService>(this IServiceCollection services, object key)
            where TService : class
            => services.AddSingleton(typeof(TService).GetKeyedType(key), typeof(TService));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceType"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static IServiceCollection AddKeyedSingleton(this IServiceCollection services, Type serviceType, object key)
            => services.AddSingleton(serviceType.GetKeyedType(key), serviceType);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="services"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static IServiceCollection AddKeyedSingleton<TService, TImplementation>(this IServiceCollection services, object key)
            where TService : class
            where TImplementation : class, TService
            => services.AddSingleton(typeof(TService).GetKeyedType(key), typeof(TImplementation));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceType"></param>
        /// <param name="key"></param>
        /// <param name="implementationFactory"></param>
        /// <returns></returns>
        public static IServiceCollection AddKeyedSingleton(this IServiceCollection services, Type serviceType, object key, Func<IServiceProvider, object> implementationFactory)
            => services.AddSingleton(serviceType.GetKeyedType(key), implementationFactory);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceType"></param>
        /// <param name="key"></param>
        /// <param name="implementationType"></param>
        /// <returns></returns>
        public static IServiceCollection AddKeyedSingleton(this IServiceCollection services, Type serviceType, object key, Type implementationType)
            => services.AddSingleton(serviceType.GetKeyedType(key), implementationType);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="services"></param>
        /// <param name="key"></param>
        /// <param name="implementationInstance"></param>
        /// <returns></returns>
        public static IServiceCollection AddKeyedSingleton<TService>(this IServiceCollection services, object key, TService implementationInstance)
            where TService : class
            => services.AddSingleton(typeof(TService).GetKeyedType(key), implementationInstance as object);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceType"></param>
        /// <param name="key"></param>
        /// <param name="implementationInstance"></param>
        /// <returns></returns>
        public static IServiceCollection AddKeyedSingleton(this IServiceCollection services, Type serviceType, object key, object implementationInstance)
            => services.AddSingleton(serviceType.GetKeyedType(key), implementationInstance);

        #endregion

        #region Transient

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="services"></param>
        /// <param name="key"></param>
        /// <param name="implementationFactory"></param>
        /// <returns></returns>
        public static IServiceCollection AddKeyedTransient<TService, TImplementation>(this IServiceCollection services, object key, Func<IServiceProvider, TImplementation> implementationFactory)
            where TService : class
            where TImplementation : class, TService
            => services.AddTransient(typeof(TService).GetKeyedType(key), sp => implementationFactory?.Invoke(sp) as object);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="services"></param>
        /// <param name="key"></param>
        /// <param name="implementationFactory"></param>
        /// <returns></returns>
        public static IServiceCollection AddKeyedTransient<TService>(this IServiceCollection services, object key, Func<IServiceProvider, TService> implementationFactory)
            where TService : class
            => services.AddTransient(typeof(TService).GetKeyedType(key), sp => implementationFactory?.Invoke(sp) as object);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="services"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static IServiceCollection AddKeyedTransient<TService>(this IServiceCollection services, object key)
            where TService : class
            => services.AddTransient(typeof(TService).GetKeyedType(key), typeof(TService));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceType"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static IServiceCollection AddKeyedTransient(this IServiceCollection services, Type serviceType, object key)
            => services.AddTransient(serviceType.GetKeyedType(key), serviceType);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="services"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static IServiceCollection AddKeyedTransient<TService, TImplementation>(this IServiceCollection services, object key)
            where TService : class
            where TImplementation : class, TService
            => services.AddTransient(typeof(TService).GetKeyedType(key), typeof(TImplementation));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceType"></param>
        /// <param name="key"></param>
        /// <param name="implementationFactory"></param>
        /// <returns></returns>
        public static IServiceCollection AddKeyedTransient(this IServiceCollection services, Type serviceType, object key, Func<IServiceProvider, object> implementationFactory)
            => services.AddTransient(serviceType.GetKeyedType(key), implementationFactory);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceType"></param>
        /// <param name="key"></param>
        /// <param name="implementationType"></param>
        /// <returns></returns>
        public static IServiceCollection AddKeyedTransient(this IServiceCollection services, Type serviceType, object key, Type implementationType)
            => services.AddTransient(serviceType.GetKeyedType(key), implementationType);

        #endregion

    }
}
