using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    /// <summary>
    /// 维修保养服务
    /// </summary>
    public class Ca_Maintenance
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual int ID { get; set; }
        /// <summary>
        /// 维修店名
        /// </summary>
        public virtual string RepairName { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public virtual string TelPhone { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public virtual string Address { get; set; }
        /// <summary>
        /// 服务描述
        /// </summary>
        public virtual string Des { get; set; }
        /// <summary>
        /// 用户组
        /// </summary>
        public virtual string UserGroupName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
    }
}
