using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Domain;

namespace Dao.Implement
{
    public class MenuPermissionsInfoRepository:RepositoryBase<MenuPermissionsInfo>,IMenuPermissionsInfoRepository
    {
        public IQueryable<MenuPermissionsInfo> LoadByGroup(int groupId)
        {
            return this.LoadAll().Where(c => c.UserGroup.ID == groupId);
        }


        public IQueryable<MenuPermissionsInfo> LoadAllByPage(out long total, int page, int rows, string order, string sort)
        {
            var list = this.LoadAll();

            total = list.LongCount();

            list = list.OrderBy(sort + " " + order);
            list = list.Skip((page - 1) * rows).Take(rows);

            return list;
        }
    }
}
