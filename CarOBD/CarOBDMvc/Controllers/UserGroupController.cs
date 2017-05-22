using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Service;

namespace CarOBDMvc.Controllers
{
    public class UserGroupController : Controller
    {
        public IUserGroupManager UserGroupManager { get; set; }

        public IDepartmentInfoManager DepartmentInfoManager { get; set; }

        public IUserInfoManager UserInfoManager { get; set; }

        public IColumnmenuPermissionsInfoManager ColumnmenuPermissionsInfoManager { get; set; }

        public IMenuPermissionsInfoManager MenuPermissionsInfoManager { get; set; }
        //
        // GET: /UserGroup/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadAllByPage(int page, int rows, string order, string sort)
        {
            long total = 0;
            var list = this.UserGroupManager.LoadAllByPage(out total, page, rows, order, sort);

            var result = new
            {
                total = total,
                rows = (from p in list
                        select new
                        {
                            p.ID,
                            p.UserGroupName,
                            p.DepartmentInfo.DepartName,
                            p.DepartmentInfo.SystemTitle,
                            p.CreateTime
                        }).ToList()
            };

            return Json(result);
        }

        public ActionResult Edit(int id = 0)
        {
 
            UserGroup usergroup = null;

            DepartmentInfo departmentInfo = null;

            if (id != 0)
            {
                usergroup = this.UserGroupManager.Get(id);
            }

            departmentInfo = departmentInfo ?? new DepartmentInfo()
            {
                DepartName = string.Empty,
                SystemTitle = string.Empty,
                ID=0
            };

            usergroup = usergroup ?? new UserGroup()
            {
                UserGroupName = string.Empty,
                DepartmentInfo = departmentInfo,
                ID = 0
            };

            ViewBag.Departments = this.DepartmentInfoManager.LoadAll();

            return View(usergroup);
        }

        [HttpPost]
        public ActionResult Exist(string usergroupname)
        {
            var result = this.UserGroupManager.Get(usergroupname) != null;

            return Json(new { IsSuccess = result.ToString() });
        }



        [HttpPost]
        public ActionResult Save(FormCollection collection)
        {
            DepartmentInfo departmentinfo = this.DepartmentInfoManager.Get(int.Parse(collection["DepartmentInfoID"]));

            if (int.Parse(collection["ID"]) == 0)
            {
                UserGroup usergroup=new UserGroup();

                usergroup.UserGroupName = collection["UserGroupName"];

                usergroup.DepartmentInfo = departmentinfo;

                usergroup.CreateTime = DateTime.Now;

                this.UserGroupManager.Save(usergroup);

            }
            else
            {

                var rolentity = this.UserGroupManager.Get(int.Parse(collection["ID"]));

                rolentity.UserGroupName = collection["UserGroupName"];

                rolentity.DepartmentInfo = departmentinfo;

                rolentity.CreateTime = DateTime.Now;

                this.UserGroupManager.Update(rolentity);
            }

            return Json(new { IsSuccess = true, Message = "保存成功" }, "text/html", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(IList<int> idList)
        {
            foreach (var item in idList)
            {
                IList<UserInfo> userInfos = this.UserInfoManager.LoadAll().Where(p => p.UserGroup.ID == item).ToList();

                if (userInfos.Count > 0)
                {
                    foreach (var userInfo in userInfos)
                    {
                        this.UserInfoManager.Delete(userInfo.ID);
                    }
                    
                }

                IList<ColumnmenuPermissionsInfo> columnmenuPermissionsInfos =
                          this.ColumnmenuPermissionsInfoManager.LoadAll()
                              .Where(p => p.UserGroup.ID == item)
                              .ToList();

                if (columnmenuPermissionsInfos.Count > 0)
                {
                    foreach (var columnmenuPermissionsInfo in columnmenuPermissionsInfos)
                    {
                        this.ColumnmenuPermissionsInfoManager.Delete(columnmenuPermissionsInfo.ID);
                    }
                }

                IList<MenuPermissionsInfo> menuPermissionsInfos =
                    this.MenuPermissionsInfoManager.LoadAll()
                        .Where(p => p.UserGroup.ID == item)
                        .ToList();


                if (menuPermissionsInfos.Count > 0)
                {
                    foreach (var menuPermissionsInfo in menuPermissionsInfos)
                    {
                        this.MenuPermissionsInfoManager.Delete(menuPermissionsInfo.ID);
                    }
                }

            }
            this.UserGroupManager.Delete(idList.Cast<object>().ToList());
            return Json(new { IsSuccess = true, Message = "删除成功" });
        }



 
    }
}
