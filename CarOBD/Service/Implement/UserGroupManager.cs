using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service.Implement
{
    public class UserGroupManager:GenericManagerBase<UserGroup>,IUserGroupManager
    {
        public IList<UserGroup> LoadAllByPage(out long total, int page, int rows, string order, string sort)
        {
            return ((Dao.IUserGroupRepository)(this.CurrentRepository)).LoadAllByPage(out total, page, rows, order, sort).ToList();
        }


        public UserGroup Get(string usergroupname)
        {
            return ((Dao.IUserGroupRepository)(this.CurrentRepository)).Get(usergroupname);
        }
    }
}
