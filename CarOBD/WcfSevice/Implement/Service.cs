using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Service;
using Spring.Context;
using Spring.Context.Support;

namespace WcfSevice.Implement
{
    public class Service:IWcfContract
    {
        public string GetData()
        {
            return "你输入的是：";
        }


        public string GetMaintenance()
        {
            IApplicationContext cxt = ContextRegistry.GetContext();

            ICa_MaintenanceManager Ca_MaintenanceManager =
                (ICa_MaintenanceManager) cxt.GetObject("Manager.Ca_Maintenance");

            IList<Ca_Maintenance> list=Ca_MaintenanceManager.LoadAll();

            return JsonConvert.SerializeObject(list);
        }
    }
}
