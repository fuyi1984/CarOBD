using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Dao
{
    public interface IMenuInfoRepository : IRepository<MenuInfo>
    {
        IQueryable<MenuInfo> LoadAllByPage(out long total, int page, int rows, string order, string sort);

        MenuInfo Get(string menuname);
    }
}
