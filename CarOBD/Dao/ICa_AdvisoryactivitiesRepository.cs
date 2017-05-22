using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Dao
{
    public interface ICa_AdvisoryactivitiesRepository : IRepository<Ca_Advisoryactivities>
    {
        IQueryable<Ca_Advisoryactivities> LoadAllByPage(out long total, int page, int rows, string order, string sort, string usergroup);

        Ca_Advisoryactivities Get(string activityname);
    }
}
