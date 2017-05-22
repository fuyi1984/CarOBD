using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Dao
{
    public interface IUserGroupRepository:IRepository<UserGroup>
    {
        IQueryable<UserGroup> LoadAllByPage(out long total, int page, int rows, string order, string sort);

        UserGroup Get(string usergroupname);
    }
}
