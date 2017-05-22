using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    /// <summary>
    /// 栏目权限信息
    /// </summary>
    public class ColumnmenuPermissionsInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual int ID { get; set; }

        /// <summary>
        /// 栏目外键
        /// </summary>
        public virtual ColumnmenuInfo ColumnmenuInfo { get; set; }

        /// <summary>
        /// 用户组外键
        /// </summary>
        public virtual UserGroup UserGroup { get; set; }

      

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
    }
}
