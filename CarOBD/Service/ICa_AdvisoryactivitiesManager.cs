using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service
{
   public interface ICa_AdvisoryactivitiesManager:IGenericManager<Ca_Advisoryactivities>
    {
       IList<Ca_Advisoryactivities> LoadAllByPage(out long total, int page, int rows, string order, string sort,string usergroup);

       Ca_Advisoryactivities Get(string activityname);
    }
}
