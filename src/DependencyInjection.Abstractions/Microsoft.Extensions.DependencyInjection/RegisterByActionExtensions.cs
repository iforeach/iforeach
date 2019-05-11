using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static partial class ServicesExtensions
    {
        /// <summary>
        /// Register services by <paramref name="registerAction"/>
        /// </summary>
        /// <param name="services"></param>
        /// <param name="registerAction"></param>
        /// <returns></returns>
        public static IServiceCollection Register(this IServiceCollection services, Func<IServiceCollection, IServiceCollection> registerAction)
        {
            return registerAction?.Invoke(services) ?? services;
        }
    }
}
