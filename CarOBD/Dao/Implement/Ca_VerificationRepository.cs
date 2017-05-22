using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Domain;

namespace Dao.Implement
{
    public class Ca_VerificationRepository : RepositoryBase<Ca_Verification>, ICa_VerificationRepository
    {
        public IQueryable<Ca_Verification> LoadAllByPage(out long total, int page, int rows, string order, string sort, string usergroup)
        {
            var list = this.LoadAll().Where(p => p.UserGroupName == usergroup);

            total = list.LongCount();

            list = list.OrderBy(sort + " " + order);
            list = list.Skip((page - 1) * rows).Take(rows);

            return list;
        }

        public Ca_Verification Get(string repairname)
        {
            return this.LoadAll().FirstOrDefault(p => p.RepairName == repairname);
        }
    }
}
