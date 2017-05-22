using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service
{
    public interface ICa_VerificationManager : IGenericManager<Ca_Verification>
    {
        IList<Ca_Verification> LoadAllByPage(out long total, int page, int rows, string order, string sort, string usergroup);

        Ca_Verification Get(string repairname);
    }
}
