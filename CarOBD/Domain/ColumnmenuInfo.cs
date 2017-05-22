using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    /// <summary>
    /// 栏目信息
    /// </summary>
    public class ColumnmenuInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual int MenuId { get; set; }
        /// <summary>
        /// 栏目名
        /// </summary>
        public virtual string MenuName { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public virtual string Icon { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }


        public virtual IList<MenuInfo> MenuInfos { get; set; }
    }
}
