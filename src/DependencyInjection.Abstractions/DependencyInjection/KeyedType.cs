using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace org.iForeach.DependencyInjection
{
    /// <summary>
    /// 命名类型
    /// </summary>
    internal sealed class KeyedType : TypeDelegator, IServiceProvider
    {
        /// <summary>
        /// 服务键 <see cref="Guid"/> 值缓存
        /// </summary>
        private readonly static ConcurrentDictionary<object, Guid> s_dictServiceKeyGuid = new ConcurrentDictionary<object, Guid>();

        /// <summary>
        /// 类型缓存
        /// </summary>
        private static readonly ConcurrentDictionary<(object ServiceKey, Type ServiceType), KeyedType> s_cache = new ConcurrentDictionary<(object ServiceKey, Type ServiceType), KeyedType>();

        /// <summary>
        /// 获取指定标识键的服务
        /// </summary>
        /// <param name="name">服务名称</param>
        /// <param name="serviceType">服务类型</param>
        /// <returns></returns>
        public static KeyedType Get(object key, Type serviceType = null) =>
            s_cache.GetOrAdd((key, serviceType), x => new KeyedType(x.ServiceKey, x.ServiceType));

        /// <summary>
        /// 私有构造函数
        /// </summary>
        /// <param name="key">类型识别键</param>
        /// <param name="serviceType">服务类型</param>
        private KeyedType(object key, Type serviceType)
            : base(typeof(object))
        {
            this.Key = key;
            this.GUID = s_dictServiceKeyGuid.GetOrAdd(key, key => Guid.NewGuid());
            this.ServiceType = serviceType;
        }

        /// <summary>
        /// 实际服务类型
        /// </summary>
        public Type ServiceType { get; }
        /// <summary>
        /// 服务标识键
        /// </summary>
        public object Key { get; }
        /// <inherit />
        public override Guid GUID { get; }
        /// <inherit />
        public override bool Equals(object obj) => this.Equals(obj as KeyedType);
        /// <inherit />
        public override int GetHashCode() => this.Key.GetHashCode();
        /// <inherit />
        public override bool Equals(Type o) => o is KeyedType t && t.Key == this.Key;
        /// <inherit />
        public override string FullName => $"NamedTypes.{this.Key?.GetType()?.FullName ?? "{null}"}-{this.Key ?? "{null}"}({this.ServiceType?.FullName})";
        /// <inherit />
        public object GetService(Type serviceType) => serviceType == typeof(Type) ? this.ServiceType : null;
    }
}
