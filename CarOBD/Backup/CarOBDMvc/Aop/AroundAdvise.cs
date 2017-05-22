using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AopAlliance.Intercept;

namespace CarOBDMvc.Aop
{
    public class AroundAdvise:IMethodInterceptor
    {
        public object Invoke(IMethodInvocation invocation)
        {
            Console.Out.WriteLine(string.Format(" 环绕通知： 调用的方法 '{0}'", invocation.Method.Name));
            Console.WriteLine();

            object returnValue = null;

            try
            {
                returnValue = invocation.Proceed();
            }
            catch
            {
                Console.Out.WriteLine(" 环绕通知： 发生异常");
                Console.WriteLine();
            }

            Console.Out.WriteLine(String.Format(" 环绕通知： 返回值 '{0}'", returnValue));

            return returnValue;
        }
    }
}
