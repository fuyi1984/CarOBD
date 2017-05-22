using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring.Aop;

namespace CarOBDMvc.Aop
{
    public class BeforeAdvise:IMethodBeforeAdvice
    {
        public void Before(System.Reflection.MethodInfo method, object[] args, object target)
        {
            Console.Out.WriteLine("     前置通知： 调用的方法名 : " + method.Name);
            Console.Out.WriteLine("     前置通知： 目标       : " + target);
            Console.Out.WriteLine("     前置通知： 参数为   : ");
            if (args != null)
            {
                foreach (object arg in args)
                {
                    Console.Out.WriteLine("\t: " + arg);
                }
            }

            Console.WriteLine();
        }
    }
}
