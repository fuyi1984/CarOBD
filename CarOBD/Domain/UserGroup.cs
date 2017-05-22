using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    /// <summary>
    /// 用户组信息
    /// </summary>
    public class UserGroup
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual int ID { get; set; }
        /// <summary>
        /// 用户组名
        /// </summary>
        public virtual string UserGroupName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 部门外键
        /// </summary>
        public virtual DepartmentInfo DepartmentInfo { get; set; }
    }
}
