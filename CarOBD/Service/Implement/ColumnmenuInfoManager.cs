using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service.Implement
{
    public class ColumnmenuInfoManager:GenericManagerBase<ColumnmenuInfo>,IColumnmenuInfoManager
    {
        public IList<ColumnmenuInfo> LoadAllByPage(out long total, int page, int rows, string order, string sort)
        {
            return ((Dao.IColumnmenuInfoRepository)(this.CurrentRepository)).LoadAllByPage(out total, page, rows, order, sort).ToList();
        }

        public ColumnmenuInfo Get(string menuname)
        {
            return ((Dao.IColumnmenuInfoRepository)(this.CurrentRepository)).Get(menuname);
        }
    }
}
