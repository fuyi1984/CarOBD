using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service.Implement
{
    public class UserInfoManager:GenericManagerBase<UserInfo>,IUserInfoManager
    {
        public UserInfo Get(string account)
        {
            return ((Dao.IUserInfoRepository) (this.CurrentRepository)).Get(account);
        }

        public UserInfo Get(string account, string password)
        {
            var entity = ((Dao.IUserInfoRepository) (this.CurrentRepository)).Get(account);

            if (entity != null)
            {
                //if (entity.Password !=
                //    this.HashCode(entity.Account.ToUpper() + password + entity.CreateTime.ToLongDateString()))
                if(entity.Password!=password)
                {
                    return null;
                }
            }

            return entity;
        }

        /// <summary>
        /// 获取MD5值
        /// </summary>
        /// <param name="key">加密的字符串</param>
        /// <returns>返回MD5值</returns>
        private string HashCode(string key)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(key, "MD5");
        }

        public void Update(UserInfo entity, string password)
        {
            //entity.Password = this.HashCode(entity.Account.ToUpper() + password + entity.CreateTime.ToLongDateString());
            entity.Password = password;
            base.Update(entity);
        }

        //public object Save(UserInfo entity)
        //{
        //    entity.Password = this.HashCode(entity.Account.ToUpper() + "123456" + entity.CreateTime.ToLongDateString());
        //    return base.Save(entity);
        //}

        public IList<UserInfo> LoadAllByPage(out long total, int page, int rows, string order, string sort)
        {
            return ((Dao.IUserInfoRepository)(this.CurrentRepository)).LoadAllByPage(out total, page, rows, order, sort).ToList();
        }
    }
}
