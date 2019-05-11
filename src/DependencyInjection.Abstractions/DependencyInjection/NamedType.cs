using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace org.iForeach.DependencyInjection
{
    /// <summary>
    /// 命名类型
    /// </summary>
    internal sealed class NamedType : TypeDelegator, IServiceProvider
    {
        /// <summary>
        /// 服务名称 <see cref="Guid"/> 值缓存
        /// </summary>
        private readonly static ConcurrentDictionary<string, Guid> s_dictServiceNameGuid 
            = new ConcurrentDictionary<string, Guid>();

        /// <summary>
        /// 类型缓存
        /// </summary>
        private static readonly ConcurrentDictionary<(string ServiceName, Type ServiceType), NamedType> s_cache
            = new ConcurrentDictionary<(string ServiceName, Type ServiceType), NamedType>();

        /// <summary>
        /// 获取指定名称的服务
        /// </summary>
        /// <param name="name">服务名称</param>
        /// <param name="serviceType">服务类型</param>
        /// <returns></returns>
        public static NamedType Get(string name, Type serviceType = null) =>
            s_cache.GetOrAdd((name, serviceType), x => new NamedType(x.ServiceName, x.ServiceType));

        /// <summary>
        /// 私有构造函数
        /// </summary>
        /// <param name="name">类型名称</param>
        /// <param name="serviceType">服务类型</param>
        private NamedType(string name, Type serviceType)
            : base(typeof(object))
        {
            this.Name = name;
            this.GUID = s_dictServiceNameGuid.GetOrAdd(name, name => Guid.NewGuid());
            this.ServiceType = serviceType;
        }

        /// <summary>
        /// 实际服务类型
        /// </summary>
        public Type ServiceType { get; }

        /// <inherit />
        public override string Name { get; }

        /// <inherit />
        public override Guid GUID { get; }

        /// <inherit />
        public override bool Equals(object obj)
            => this.Equals(obj as NamedType);
        /// <inherit />
        public override int GetHashCode()
            => this.Name.GetHashCode();

        /// <inherit />
        public override bool Equals(Type o)
            => o is NamedType t && t.Name == this.Name;

        /// <inherit />
        public override string FullName
            => $"NamedTypes.{this.Name}({this.ServiceType?.FullName})";

        /// <inherit />
        public object GetService(Type serviceType)
            => serviceType == typeof(Type) ? this.ServiceType : null;
    }
}
