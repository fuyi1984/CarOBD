using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service
{
    public interface IColumnmenuInfoManager:IGenericManager<ColumnmenuInfo>
    {
        IList<ColumnmenuInfo> LoadAllByPage(out long total, int page, int rows, string order, string sort);

        ColumnmenuInfo Get(string menuname);
    }
}
