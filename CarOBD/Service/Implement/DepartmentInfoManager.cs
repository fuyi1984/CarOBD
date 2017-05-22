using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service.Implement
{
    public class DepartmentInfoManager:GenericManagerBase<DepartmentInfo>,IDepartmentInfoManager
    {

        public IList<DepartmentInfo> LoadAllByPage(out long total,  int page, int rows, string order, string sort)
        {
            return ((Dao.IDepartmentInfoRepository)(this.CurrentRepository))
                .LoadAllByPage(out total,  page, rows, order, sort).ToList();
        }


        public DepartmentInfo Get(string departname, string systitle)
        {
            return ((Dao.IDepartmentInfoRepository)(this.CurrentRepository)).Get(departname,systitle);
        }
    }
}
