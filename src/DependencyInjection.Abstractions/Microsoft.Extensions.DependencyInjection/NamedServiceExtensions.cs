using System;

using org.iForeach.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 命名服务扩展方法
    /// </summary>
    public static partial class ServicesExtensions
    {
        private static Type GetNamedType(this Type serviceType, string name)
            => NamedType.Get(name, serviceType);

        #region Socped

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="services"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IServiceCollection AddNamedScoped<TService>(this IServiceCollection services, string name)
            where TService : class
            => services.AddScoped(typeof(TService).GetNamedType(name), typeof(TService));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceType"></param>
        /// <param name="implementationType"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IServiceCollection AddNamedScoped(this IServiceCollection services, Type serviceType, string name, Type implementationType)
            => services.AddScoped(serviceType.GetNamedType(name), implementationType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceType"></param>
        /// <param name="implementationFactory"></param>
        /// <returns></returns>
        public static IServiceCollection AddNamedScoped(this IServiceCollection services, Type serviceType, string name, Func<IServiceProvider, object> implementationFactory)
            => services.AddScoped(serviceType.GetNamedType(name), implementationFactory);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddNamedScoped<TService, TImplementation>(this IServiceCollection services, string name)
            where TService : class
            where TImplementation : class, TService
               => services.AddScoped(typeof(TService).GetNamedType(name), typeof(TImplementation));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public static IServiceCollection AddNamedScoped(this IServiceCollection services, Type serviceType, string name)
            => services.AddScoped(serviceType.GetNamedType(name), serviceType);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="services"></param>
        /// <param name="implementationFactory"></param>
        /// <returns></returns>
        public static IServiceCollection AddNamedScoped<TService>(this IServiceCollection services, string name, Func<IServiceProvider, TService> implementationFactory)
            where TService : class
            => services.AddScoped(typeof(TService).GetNamedType(name), implementationFactory);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="services"></param>
        /// <param name="implementationFactory"></param>
        /// <returns></returns>
        public static IServiceCollection AddNamedScoped<TService, TImplementation>(this IServiceCollection services, string name, Func<IServiceProvider, TImplementation> implementationFactory)
            where TService : class
            where TImplementation : class, TService
            => services.AddScoped(typeof(TService).GetNamedType(name), implementationFactory);

        #endregion

        #region Singleton

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="services"></param>
        /// <param name="name"></param>
        /// <param name="implementationFactory"></param>
        /// <returns></returns>
        public static IServiceCollection AddNamedSingleton<TService, TImplementation>(this IServiceCollection services, string name, Func<IServiceProvider, TImplementation> implementationFactory)
            where TService : class
            where TImplementation : class, TService
            => services.AddSingleton(typeof(TService).GetNamedType(name), sp => implementationFactory?.Invoke(sp) as object);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="services"></param>
        /// <param name="name"></param>
        /// <param name="implementationFactory"></param>
        /// <returns></returns>
        public static IServiceCollection AddNamedSingleton<TService>(this IServiceCollection services, string name, Func<IServiceProvider, TService> implementationFactory)
            where TService : class
            => services.AddSingleton(typeof(TService).GetNamedType(name), sp => implementationFactory?.Invoke(sp) as object);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="services"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IServiceCollection AddNamedSingleton<TService>(this IServiceCollection services, string name)
            where TService : class
            => services.AddSingleton(typeof(TService).GetNamedType(name), typeof(TService));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceType"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IServiceCollection AddNamedSingleton(this IServiceCollection services, Type serviceType, string name)
            => services.AddSingleton(serviceType.GetNamedType(name), serviceType);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="services"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IServiceCollection AddNamedSingleton<TService, TImplementation>(this IServiceCollection services, string name)
            where TService : class
            where TImplementation : class, TService
            => services.AddSingleton(typeof(TService).GetNamedType(name), typeof(TImplementation));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceType"></param>
        /// <param name="name"></param>
        /// <param name="implementationFactory"></param>
        /// <returns></returns>
        public static IServiceCollection AddNamedSingleton(this IServiceCollection services, Type serviceType, string name, Func<IServiceProvider, object> implementationFactory)
            => services.AddSingleton(serviceType.GetNamedType(name), implementationFactory);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceType"></param>
        /// <param name="name"></param>
        /// <param name="implementationType"></param>
        /// <returns></returns>
        public static IServiceCollection AddNamedSingleton(this IServiceCollection services, Type serviceType, string name, Type implementationType)
            => services.AddSingleton(serviceType.GetNamedType(name), implementationType);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="services"></param>
        /// <param name="name"></param>
        /// <param name="implementationInstance"></param>
        /// <returns></returns>
        public static IServiceCollection AddNamedSingleton<TService>(this IServiceCollection services, string name, TService implementationInstance)
            where TService : class
            => services.AddSingleton(typeof(TService).GetNamedType(name), (object)implementationInstance);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceType"></param>
        /// <param name="name"></param>
        /// <param name="implementationInstance"></param>
        /// <returns></returns>
        public static IServiceCollection AddNamedSingleton(this IServiceCollection services, Type serviceType, string name, object implementationInstance)
            => services.AddSingleton(serviceType.GetNamedType(name), implementationInstance);

        #endregion

        #region Transient

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="services"></param>
        /// <param name="name"></param>
        /// <param name="implementationFactory"></param>
        /// <returns></returns>
        public static IServiceCollection AddNamedTransient<TService, TImplementation>(this IServiceCollection services, string name, Func<IServiceProvider, TImplementation> implementationFactory)
            where TService : class
            where TImplementation : class, TService
            => services.AddTransient(typeof(TService).GetNamedType(name), sp => implementationFactory?.Invoke(sp) as object);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="services"></param>
        /// <param name="name"></param>
        /// <param name="implementationFactory"></param>
        /// <returns></returns>
        public static IServiceCollection AddNamedTransient<TService>(this IServiceCollection services, string name, Func<IServiceProvider, TService> implementationFactory)
            where TService : class
            => services.AddTransient(typeof(TService).GetNamedType(name), sp => implementationFactory?.Invoke(sp) as object);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="services"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IServiceCollection AddNamedTransient<TService>(this IServiceCollection services, string name)
            where TService : class
            => services.AddTransient(typeof(TService).GetNamedType(name), typeof(TService));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceType"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IServiceCollection AddNamedTransient(this IServiceCollection services, Type serviceType, string name)
            => services.AddTransient(serviceType.GetNamedType(name), serviceType);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="services"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IServiceCollection AddNamedTransient<TService, TImplementation>(this IServiceCollection services, string name)
            where TService : class
            where TImplementation : class, TService
            => services.AddTransient(typeof(TService).GetNamedType(name), typeof(TImplementation));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceType"></param>
        /// <param name="name"></param>
        /// <param name="implementationFactory"></param>
        /// <returns></returns>
        public static IServiceCollection AddNamedTransient(this IServiceCollection services, Type serviceType, string name, Func<IServiceProvider, object> implementationFactory)
            => services.AddTransient(serviceType.GetNamedType(name), implementationFactory);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceType"></param>
        /// <param name="name"></param>
        /// <param name="implementationType"></param>
        /// <returns></returns>
        public static IServiceCollection AddNamedTransient(this IServiceCollection services, Type serviceType, string name, Type implementationType)
            => services.AddTransient(serviceType.GetNamedType(name), implementationType);

        #endregion

    }
}
