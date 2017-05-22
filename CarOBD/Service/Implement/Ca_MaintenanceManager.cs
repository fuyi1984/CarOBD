using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service.Implement
{
    public class Ca_MaintenanceManager : GenericManagerBase<Ca_Maintenance>, ICa_MaintenanceManager
    {
        public IList<Ca_Maintenance> LoadAllByPage(out long total, int page, int rows, string order, string sort, string usergroup)
        {
            return ((Dao.ICa_MaintenanceRepository)(this.CurrentRepository)).LoadAllByPage(out total, page, rows, order, sort,usergroup).ToList();
        }


        public Ca_Maintenance Get(string repairname)
        {
            return ((Dao.ICa_MaintenanceRepository)(this.CurrentRepository)).Get(repairname);
        }
    }
}
