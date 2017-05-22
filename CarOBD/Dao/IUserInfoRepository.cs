using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Dao
{
    public interface IUserInfoRepository:IRepository<UserInfo>
    {
        IQueryable<UserInfo> LoadAllByPage(out long total, int page, int rows, string order, string sort);

        UserInfo Get(string account);
    }
}
