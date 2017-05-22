using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service.Implement
{
    public class Ca_VerificationManager : GenericManagerBase<Ca_Verification>, ICa_VerificationManager
    {
        public IList<Ca_Verification> LoadAllByPage(out long total, int page, int rows, string order, string sort, string usergroup)
        {
            return ((Dao.ICa_VerificationRepository)(this.CurrentRepository)).LoadAllByPage(out total, page, rows, order, sort, usergroup).ToList();
        }

        public Ca_Verification Get(string repairname)
        {
            return ((Dao.ICa_VerificationRepository)(this.CurrentRepository)).Get(repairname);
        }
    }
}
