using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Dao
{
    public interface IMenuPermissionsInfoRepository:IRepository<MenuPermissionsInfo>
    {
        IQueryable<MenuPermissionsInfo> LoadByGroup(int groupId);


        IQueryable<MenuPermissionsInfo> LoadAllByPage(out long total, int page, int rows, string order, string sort);
    }
}
