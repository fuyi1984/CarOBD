using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service.Implement
{
    public class ColumnmenuPermissionsInfoManager:GenericManagerBase<ColumnmenuPermissionsInfo>,IColumnmenuPermissionsInfoManager
    {
        public IList<ColumnmenuPermissionsInfo> LoadByGroup(int groupId)
        {
            return ((Dao.IColumnmenuPermissionsInfoRepository)(this.CurrentRepository)).LoadByGroup(groupId).ToList();
        }


        public IList<ColumnmenuPermissionsInfo> LoadAllByPage(out long total, int page, int rows, string order, string sort)
        {
            return ((Dao.IColumnmenuPermissionsInfoRepository)(this.CurrentRepository)).LoadAllByPage(out total, page, rows, order, sort).ToList();
        }


        public IList<ColumnmenuPermissionsInfo> LoadByColumnmenuInfoId(int columnmenuInfoId)
        {
            return ((Dao.IColumnmenuPermissionsInfoRepository)(this.CurrentRepository)).LoadByColumnmenuInfoId(columnmenuInfoId).ToList();
        }
    }
}
