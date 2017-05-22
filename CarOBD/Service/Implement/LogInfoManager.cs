using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service.Implement
{
    public class LogInfoManager:GenericManagerBase<LogInfo>,ILogInfoManager
    {
        public IList<LogInfo> LoadAllByPage(out long total, int page, int rows, string order, string sort)
        {
            return ((Dao.ILogInfoRepository)(this.CurrentRepository)).LoadAllByPage(out total, page, rows, order, sort).ToList();
        }
    }
}
