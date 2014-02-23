using Castle.DynamicProxy;
using System.Diagnostics;
using System.Runtime.Caching;

namespace AOPCaching
{
public class CacheInterceptor : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        Debug.WriteLine("Enter interceptor...");
        Debug.WriteLine("Invoke {0}.{1}", invocation.Method.DeclaringType.FullName, invocation.Method.Name);

        string key = string.Format("{0}.{1}", invocation.Method.DeclaringType.FullName, invocation.Method.Name);
        ObjectCache cache = MemoryCache.Default;
        object item = cache.Get(key);

        if (item == null)
        {
            invocation.Proceed();
            Debug.WriteLine("Set cache...");
            cache.Set(key, invocation.ReturnValue, new CacheItemPolicy());
            return;
        }

        Debug.WriteLine("Return cache...");
        invocation.ReturnValue = item;
        Debug.WriteLine("Leave interceptor...");
    }
}
}