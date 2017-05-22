using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service
{
    public interface IColumnmenuPermissionsInfoManager:IGenericManager<ColumnmenuPermissionsInfo>
    {
        IList<ColumnmenuPermissionsInfo> LoadByGroup(int groupId);

        IList<ColumnmenuPermissionsInfo> LoadAllByPage(out long total, int page, int rows, string order, string sort);

        IList<ColumnmenuPermissionsInfo> LoadByColumnmenuInfoId(int columnmenuInfoId);
    }
}
