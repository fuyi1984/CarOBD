using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    /// <summary>
    /// 菜单信息
    /// </summary>
    public class MenuInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual int MenuId { get; set; }
        /// <summary>
        /// 菜单名
        /// </summary>
        public virtual string MenuNames { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public virtual string Icon { get; set; }
        /// <summary>
        /// Url
        /// </summary>
        public virtual string Url { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }

    }
}
