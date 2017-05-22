using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Security.Permissions;
using System.Text;
using Domain;

namespace Dao.Implement
{
    public class DepartmentInfoRepository:RepositoryBase<DepartmentInfo>,IDepartmentInfoRepository
    {
        public object SaveDepartmentInfo(DepartmentInfo entity)
        {
            return this.Save(entity);
        }

        public IQueryable<DepartmentInfo> LoadAllByPage(out long total, int page, int rows, string order, string sort)
        {
            var list = this.LoadAll();

            total = list.LongCount();

            list = list.OrderBy(sort + " " + order);

            list = list.Skip((page - 1)*rows).Take(rows);

            return list;
        }


        public DepartmentInfo Get(string departname, string systitle)
        {
            return this.LoadAll().FirstOrDefault(f => f.DepartName==departname&&f.SystemTitle==systitle);
        }
    }
}
