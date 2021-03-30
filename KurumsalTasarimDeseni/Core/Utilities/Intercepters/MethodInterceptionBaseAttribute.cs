using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Intercepters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        /// <summary>
        /// kodu okuma sırasını belirtir.
        /// </summary>
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {
            throw new NotImplementedException();
        }
    }
}
