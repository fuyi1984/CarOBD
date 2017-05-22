using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    /// <summary>
    /// 部门信息
    /// </summary>
    public class DepartmentInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual int ID { get; set; }
        /// <summary>
        /// 部门名
        /// </summary>
        public virtual string DepartName { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public virtual string PersonName { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public virtual string TelPhone { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public virtual string Address { get; set; }
        /// <summary>
        /// 系统标题
        /// </summary>
        public virtual string SystemTitle { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
    }
}
