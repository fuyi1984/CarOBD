using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace WcfSevice
{
    [ServiceContract]
    public interface IWcfContract
    {
        [OperationContract]
        string GetData();

        [OperationContract]
        string GetMaintenance();
    }
}
