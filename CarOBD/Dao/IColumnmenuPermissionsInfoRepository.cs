using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Dao
{
    public interface IColumnmenuPermissionsInfoRepository:IRepository<ColumnmenuPermissionsInfo>
    {
        IQueryable<ColumnmenuPermissionsInfo> LoadByGroup(int groupId);

        IQueryable<ColumnmenuPermissionsInfo> LoadByColumnmenuInfoId(int columnmenuInfoId);

        IQueryable<ColumnmenuPermissionsInfo> LoadAllByPage(out long total, int page, int rows, string order, string sort);

    }
}
