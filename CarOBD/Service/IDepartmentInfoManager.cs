using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service
{
    public interface IDepartmentInfoManager:IGenericManager<DepartmentInfo>
    {
        IList<DepartmentInfo> LoadAllByPage(out long total,  int page, int rows, string order, string sort);

        DepartmentInfo Get(string departname,string systitle);
    }
}
