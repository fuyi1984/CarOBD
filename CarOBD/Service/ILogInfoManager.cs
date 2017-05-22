using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service
{
    public interface ILogInfoManager:IGenericManager<LogInfo>
    {
        IList<LogInfo> LoadAllByPage(out long total, int page, int rows, string order, string sort);
    }
}
