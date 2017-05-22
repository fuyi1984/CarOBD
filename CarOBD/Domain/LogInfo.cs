using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    /// <summary>
    /// 登录日志信息
    /// </summary>
    public class LogInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual int ID { get; set; }
        /// <summary>
        /// IP所在地址
        /// </summary>
        public virtual string IpAddress { get; set; }
        /// <summary>
        /// 登录IP
        /// </summary>
        public virtual string IpInfo { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public virtual string Account { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
    }
}
