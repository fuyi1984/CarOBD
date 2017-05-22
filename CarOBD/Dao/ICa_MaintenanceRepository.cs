using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Dao
{
    public interface ICa_MaintenanceRepository:IRepository<Ca_Maintenance>
    {
        IQueryable<Ca_Maintenance> LoadAllByPage(out long total, int page, int rows, string order, string sort, string usergroup);

        Ca_Maintenance Get(string repairname);
    }
}
