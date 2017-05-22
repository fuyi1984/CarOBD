using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service
{
    public interface ICa_MaintenanceManager:IGenericManager<Ca_Maintenance>
    {
        IList<Ca_Maintenance> LoadAllByPage(out long total, int page, int rows, string order, string sort,string usergroup);

        Ca_Maintenance Get(string repairname);
    }
}
