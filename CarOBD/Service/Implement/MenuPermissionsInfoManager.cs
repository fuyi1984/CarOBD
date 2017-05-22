using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service.Implement
{
    public class MenuPermissionsInfoManager:GenericManagerBase<MenuPermissionsInfo>,IMenuPermissionsInfoManager
    {
        public IList<MenuPermissionsInfo> LoadByGroup(int groupId)
        {
            return ((Dao.IMenuPermissionsInfoRepository)(this.CurrentRepository)).LoadByGroup(groupId).ToList();
        }


        public IList<MenuPermissionsInfo> LoadAllByPage(out long total, int page, int rows, string order, string sort)
        {
            return ((Dao.IMenuPermissionsInfoRepository)(this.CurrentRepository)).LoadAllByPage(out total, page, rows, order, sort).ToList();
        }
    }
}
