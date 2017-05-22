using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Dao
{
    public interface ICa_VerificationRepository : IRepository<Ca_Verification>
    {
        IQueryable<Ca_Verification> LoadAllByPage(out long total, int page, int rows, string order, string sort, string usergroup);

        Ca_Verification Get(string repairname);
    }
}
