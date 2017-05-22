using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Domain;

namespace Dao.Implement
{
    public class Ca_AdvisoryactivitiesRepository : RepositoryBase<Ca_Advisoryactivities>,ICa_AdvisoryactivitiesRepository
    {
        public IQueryable<Ca_Advisoryactivities> LoadAllByPage(out long total, int page, int rows, string order, string sort, string usergroup)
        {
            var list = this.LoadAll().Where(p => p.UserGroupName == usergroup);

            total = list.LongCount();

            list = list.OrderBy(sort + " " + order);
            list = list.Skip((page - 1) * rows).Take(rows);

            return list;
        }

        public Ca_Advisoryactivities Get(string activityname)
        {
            return this.LoadAll().FirstOrDefault(p => p.ActivityName == activityname);
        }
    }
}
