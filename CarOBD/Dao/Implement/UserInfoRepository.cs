using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using System.Linq.Dynamic;

namespace Dao.Implement
{
    public class UserInfoRepository:RepositoryBase<UserInfo>,IUserInfoRepository
    {
        public UserInfo Get(string account)
        {
            return this.LoadAll().FirstOrDefault(f => f.Account == account);
        }

        public IQueryable<UserInfo> LoadAllByPage(out long total, int page, int rows, string order, string sort)
        {
            var list = this.LoadAll();

            total = list.LongCount();

            list = list.OrderBy(sort + " " + order);
            list = list.Skip((page - 1) * rows).Take(rows);

            return list;

        }
    }
}
