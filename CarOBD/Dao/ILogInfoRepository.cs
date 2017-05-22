using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Dao
{
    public interface ILogInfoRepository : IRepository<LogInfo>
    {
        IQueryable<LogInfo> LoadAllByPage(out long total, int page, int rows, string order, string sort);
    }
}
