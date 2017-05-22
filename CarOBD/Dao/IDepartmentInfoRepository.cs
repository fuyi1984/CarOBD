using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Dao
{
    public interface IDepartmentInfoRepository:IRepository<DepartmentInfo>
    {
        IQueryable<DepartmentInfo> LoadAllByPage(out long total,int page, int rows, string order, string sort);

        object SaveDepartmentInfo(DepartmentInfo entity);

        DepartmentInfo Get(string departname,string systitle);
    }
}
