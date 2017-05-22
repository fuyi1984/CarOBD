using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    /// <summary>
    /// 目录权限信息
    /// </summary>
    public class MenuPermissionsInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual int ID { get; set; }

        /// <summary>
        /// 菜单外键
        /// </summary>
        public virtual MenuInfo MenuInfo { get; set; }

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
