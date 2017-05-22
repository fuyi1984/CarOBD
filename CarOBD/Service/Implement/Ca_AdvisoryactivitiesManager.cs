using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service.Implement
{
    public class Ca_AdvisoryactivitiesManager : GenericManagerBase<Ca_Advisoryactivities>, ICa_AdvisoryactivitiesManager
    {
        public IList<Ca_Advisoryactivities> LoadAllByPage(out long total, int page, int rows, string order, string sort, string usergroup)
        {
            return ((Dao.ICa_AdvisoryactivitiesRepository)(this.CurrentRepository)).LoadAllByPage(out total, page, rows, order, sort, usergroup).ToList();
        }

        public Ca_Advisoryactivities Get(string activityname)
        {
            return ((Dao.ICa_AdvisoryactivitiesRepository)(this.CurrentRepository)).Get(activityname);
        }
    }
}
