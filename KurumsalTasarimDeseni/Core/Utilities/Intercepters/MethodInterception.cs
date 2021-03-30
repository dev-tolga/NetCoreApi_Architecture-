using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;

namespace Core.Utilities.Intercepters
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation)
        {
            //NOT : method çalışmadan önce çalışmaktadır.
        }
        protected virtual void OnAfter(IInvocation invocation)
        {
            //NOT : method çalıştıktan sonra çalışmaktadır.
        }
        protected virtual void OnException(IInvocation invocation, System.Exception e)
        {
            //NOT : method hata aldıktan sonra
        }
        protected virtual void OnSuccess(IInvocation invocation)
        {
            //NOT : method başarılı çalıştıktan sonras
        }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;

            OnBefore(invocation);

            try
            {
                invocation.Proceed();//methodu çalıştır demek.
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }

            OnAfter(invocation);
        }
    }
}
