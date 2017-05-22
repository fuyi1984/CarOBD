using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Context;
using Spring.Context.Support;
using WcfSevice;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();

            IWcfContract webProxy = (IWcfContract) cxt.GetObject("WebProxy");
            Console.WriteLine(webProxy.GetMaintenance());

            Console.ReadLine();

        }
    }

}
