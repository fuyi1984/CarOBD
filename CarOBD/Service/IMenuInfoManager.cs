using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service
{
    public interface IMenuInfoManager:IGenericManager<MenuInfo>
    {
        IList<MenuInfo> LoadAllByPage(out long total, int page, int rows, string order, string sort);

        MenuInfo Get(string menuname);
    }
}
