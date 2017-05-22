using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;
using Common;
using Domain;
using Service;
using Service.Implement;
using Spring.Context;
using Spring.Context.Support;
using Spring.Web.Mvc;

namespace CarOBDMvc
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : SpringMvcApplication
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger("Logger");

        protected override void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();

            base.Application_Start(sender, e);

            SetInit();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            if (this.Server.GetLastError() == null)
            {
                return;
            }

            Exception ex = this.Server.GetLastError().GetBaseException();
            StringBuilder sb = new StringBuilder();

            sb.Append(ex.Message);
            sb.Append("\r\nSOURCE: " + ex.Source);
            if (Request.Form != null)
            {
                sb.Append("\r\nFORM: " + this.Request.Form.ToString());
            }
            if (Request.QueryString != null)
            {
                sb.Append("\r\nQUERYSTRING: " + this.Request.QueryString.ToString());
            }

            sb.Append("\r\n引发当前异常的原因: " + ex.TargetSite);
            sb.Append("\r\n堆栈跟踪: " + ex.StackTrace);
            logger.Error(sb.ToString());

            var key = System.Configuration.ConfigurationManager.AppSettings["IsDebug"];
            bool isDebug;
            if (!bool.TryParse(key, out isDebug) || !isDebug)
            {
                this.Server.ClearError();
            }
        }

        protected override void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // 路由名称
                "{controller}/{action}/{id}", // 带有参数的 URL
                new { controller = "Home", action = "Login", id = UrlParameter.Optional } // 参数默认值
            );

        }

        /// <summary>
        /// 设置初始账号
        /// </summary>
        private void SetInit()
        {
            IApplicationContext cxt = ContextRegistry.GetContext();

            #region 初始化机构

            IDepartmentInfoManager departmentInfoManager =
                (IDepartmentInfoManager) cxt.GetObject("Manager.DepartmentInfo");

            const string departname = "重庆市";
            const string systemtitle = "沙坪坝";

            var department = departmentInfoManager.Get(departname, systemtitle);

            if (department == null)
            {
                department = new DepartmentInfo()
                {
                    DepartName = departname,
                    SystemTitle = systemtitle,
                    CreateTime = DateTime.Now
                };

                departmentInfoManager.Save(department);
            }

            #endregion

            #region 初始化用户组

            IUserGroupManager UserGroupManager = (IUserGroupManager) cxt.GetObject("Manager.UserGroup");

            const string usergroupname = "沙坪坝区";

            var usergroup = UserGroupManager.Get(usergroupname);

            if (usergroup == null)
            {
                usergroup = new UserGroup()
                {
                    UserGroupName = usergroupname,
                    DepartmentInfo = department,
                    CreateTime = DateTime.Now
                };

                UserGroupManager.Save(usergroup);
            }

            #endregion

            #region 初始化用户

            IUserInfoManager userinfomanager = (IUserInfoManager) cxt.GetObject("Manager.UserInfo");

            const string account = "admin";
            string password = EncodeHelper.DesEncrypt("admin");

            var user = userinfomanager.Get(account);

            if (user == null)
            {
                user = new Domain.UserInfo
                {
                    Account = account,
                    Name = "超级管理员",
                    Password = password,
                    CreateTime = DateTime.Now,
                    IsEnabled = true,
                    UserGroup = usergroup
                };

                userinfomanager.Save(user);
            }

            #endregion

            #region 初始化菜单

            IMenuInfoManager MenuInfoManager = (IMenuInfoManager) cxt.GetObject("Manager.MenuInfo");

            string[] arrayA = {"机构管理", "用户管理", "系统日志", "用户组管理", "栏目管理", "栏目权限", "菜单分配", "菜单权限", "菜单管理", "图片上传", "图片墙"};

            string[] arrayB =
            {
                "/DepartmentInfo/Index", "/UserInfo/Index", "/LogInfo/Index", "/UserGroup/Index",
                "/ColumnmenuInfo/Index", "/ColumnmenuPermissionsInfo/Index", "/MenuInfo/Index",
                "/MenuPermissionsInfo/Index", "/MenuInfo/Detail", "/Photos/Index", "/Photos/Photo"
            };

            MenuInfo[] menuInfo = new MenuInfo[11];

            for (int i = 0; i < arrayA.Length; i++)
            {
                var menuinfo = MenuInfoManager.Get(arrayA[i]);

                if (menuinfo == null)
                {
                    menuinfo = new MenuInfo
                    {
                        Icon = "icon-add",
                        MenuNames = arrayA[i],
                        Url = arrayB[i],
                        CreateTime = DateTime.Now
                    };
                    menuInfo[i] = menuinfo;
                    MenuInfoManager.Save(menuinfo);
                }
            }


            #endregion

            #region 初始化栏目

            IColumnmenuInfoManager ColumnmenuInfoManager =
                (IColumnmenuInfoManager) cxt.GetObject("Manager.ColumnmenuInfo");

            const string columnmenu01 = "系统管理";
            const string columnmenu02 = "权限管理";

            var columnmenu_01 = ColumnmenuInfoManager.Get(columnmenu01);
            var columnmenu_02 = ColumnmenuInfoManager.Get(columnmenu02);


            if (columnmenu_01 == null)
            {
                columnmenu_01 = new ColumnmenuInfo()
                {
                    MenuName = columnmenu01,
                    Icon = "icon-sys",
                    MenuInfos = new List<MenuInfo>()
                    {
                        menuInfo[0],
                        menuInfo[1],
                        menuInfo[2],
                        menuInfo[3],
                        menuInfo[4],
                        menuInfo[6],
                        menuInfo[8],
                        menuInfo[9],
                        menuInfo[10]
                    },
                    CreateTime = DateTime.Now
                };

                ColumnmenuInfoManager.SaveOrUpdate(columnmenu_01);
            }

            if (columnmenu_02 == null)
            {
                columnmenu_02 = new ColumnmenuInfo()
                {
                    MenuName = columnmenu02,
                    Icon = "icon-sys",
                    MenuInfos = new List<MenuInfo>()
                    {
                        menuInfo[5],
                        menuInfo[7]
                    },
                    CreateTime = DateTime.Now
                };

                ColumnmenuInfoManager.SaveOrUpdate(columnmenu_02);
            }

            #endregion

            #region 初始化栏目权限

            IColumnmenuPermissionsInfoManager ColumnmenuPermissionsInfoManager =
                (IColumnmenuPermissionsInfoManager) cxt.GetObject("Manager.ColumnmenuPermissionsInfo");


            var ColumnmenuPermissionsInfo01 =
                ColumnmenuPermissionsInfoManager.LoadAll()
                    .FirstOrDefault(
                        f => f.ColumnmenuInfo.MenuName == columnmenu01 && f.UserGroup.UserGroupName == usergroupname);

            if (ColumnmenuPermissionsInfo01 == null)
            {
                ColumnmenuPermissionsInfo01 = new ColumnmenuPermissionsInfo()
                {
                    ColumnmenuInfo = columnmenu_01,
                    UserGroup = usergroup,
                    CreateTime = DateTime.Now
                };
                ColumnmenuPermissionsInfoManager.Save(ColumnmenuPermissionsInfo01);
            }

            var ColumnmenuPermissionsInfo02 =
                ColumnmenuPermissionsInfoManager.LoadAll()
                    .FirstOrDefault(
                        f => f.ColumnmenuInfo.MenuName == columnmenu02 && f.UserGroup.UserGroupName == usergroupname);

            if (ColumnmenuPermissionsInfo02 == null)
            {
                ColumnmenuPermissionsInfo02 = new ColumnmenuPermissionsInfo()
                {
                    ColumnmenuInfo = columnmenu_02,
                    UserGroup = usergroup,
                    CreateTime = DateTime.Now
                };
                ColumnmenuPermissionsInfoManager.Save(ColumnmenuPermissionsInfo02);
            }

            #endregion

            #region 初始化菜单权限

            IMenuPermissionsInfoManager MenuPermissionsInfoManager =
                (IMenuPermissionsInfoManager) cxt.GetObject("Manager.MenuPermissionsInfo");

            for (int i = 0; i < arrayA.Length; i++)
            {

                var MenuPermissionsInfo =
                    MenuPermissionsInfoManager.LoadAll()
                        .FirstOrDefault(
                            f => f.MenuInfo.MenuNames == arrayA[i] && f.UserGroup.UserGroupName == usergroupname);

                if (MenuPermissionsInfo == null)
                {
                    var menu = MenuInfoManager.Get(arrayA[i]);

                    MenuPermissionsInfo = new MenuPermissionsInfo()
                    {
                        MenuInfo = menu,
                        UserGroup = usergroup,
                        CreateTime = DateTime.Now
                    };
                    MenuPermissionsInfoManager.Save(MenuPermissionsInfo);
                }
            }


            #endregion

        }
    }

}