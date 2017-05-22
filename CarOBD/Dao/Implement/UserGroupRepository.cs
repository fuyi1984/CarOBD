using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Domain;

namespace Dao.Implement
{
    public class UserGroupRepository : RepositoryBase<UserGroup>, IUserGroupRepository
    {
       

        public IQueryable<UserGroup> LoadAllByPage(out long total, int page, int rows, string order, string sort)
        {
            var list = this.LoadAll();

            total = list.LongCount();

            list = list.OrderBy(sort + " " + order);
            list = list.Skip((page - 1) * rows).Take(rows);

            return list;
        }


        public UserGroup Get(string usergroupname)
        {
            return this.LoadAll().FirstOrDefault(f => f.UserGroupName == usergroupname);
        }
    }
}
