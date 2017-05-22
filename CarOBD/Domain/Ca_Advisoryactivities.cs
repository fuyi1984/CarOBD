using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    /// <summary>
    /// 咨询活动
    /// </summary>
    public class Ca_Advisoryactivities
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual int ID { get; set; }
        /// <summary>
        /// 活动名
        /// </summary>
        public virtual string ActivityName { get; set; }
        /// <summary>
        /// 咨询电话
        /// </summary>
        public virtual string TelPhone { get; set; }
        /// <summary>
        /// 活动地址
        /// </summary>
        public virtual string Address { get; set; }
        /// <summary>
        /// 活动内容
        /// </summary>
        public virtual string Context { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public virtual DateTime BeginTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public virtual DateTime EndTime { get; set; }
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
