using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service.Implement
{
    public class MenuInfoManager:GenericManagerBase<MenuInfo>,IMenuInfoManager
    {
        public IList<MenuInfo> LoadAllByPage(out long total, int page, int rows, string order, string sort)
        {
            return ((Dao.IMenuInfoRepository)(this.CurrentRepository)).LoadAllByPage(out total, page, rows, order, sort).ToList();
        }


        public MenuInfo Get(string menuname)
        {
            return ((Dao.IMenuInfoRepository)(this.CurrentRepository)).Get(menuname);
        }
    }
}
