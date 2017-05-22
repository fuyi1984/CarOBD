using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service
{
    public interface IMenuPermissionsInfoManager:IGenericManager<MenuPermissionsInfo>
    {
        IList<MenuPermissionsInfo> LoadByGroup(int groupId);

        IList<MenuPermissionsInfo> LoadAllByPage(out long total, int page, int rows, string order, string sort);
    }
}
