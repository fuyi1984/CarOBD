using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Domain;

namespace CarOBDMvc.Controllers
{
    public class DepartmentInfoController : Controller
    {
        public IDepartmentInfoManager DepartmentInfoManager { get; set; }

        public IUserGroupManager UserGroupManager { get; set; }

        public IUserInfoManager UserInfoManager { get; set; }

        public IColumnmenuPermissionsInfoManager ColumnmenuPermissionsInfoManager { get; set; }

        public IMenuPermissionsInfoManager MenuPermissionsInfoManager { get; set; }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize] 
        public ActionResult LoadAllByPage(int page, int rows, string order, string sort)
        {
            long total = 0;
            var list = this.DepartmentInfoManager.LoadAllByPage(out total, page, rows, order, sort).Select(entity => new
            {
                entity.PersonName,
                entity.DepartName,
                entity.TelPhone,
                entity.Address,
                entity.SystemTitle,
                entity.CreateTime,
                entity.ID
            });

            var result = new { total = total, rows = list.ToList() };

            return Json(result);
        }

        //
        // GET: /DepartmentInfo/Edit/5
 
        public ActionResult Edit(int id=0)
        {
            DepartmentInfo entity = null;

            if (id != 0)
            {
                entity = this.DepartmentInfoManager.Get(id);
            }

            entity = entity ?? new DepartmentInfo
            {
                Address = string.Empty,
                DepartName = string.Empty,
                PersonName = string.Empty,
                SystemTitle = string.Empty,
                TelPhone = string.Empty,
                ID = 0
            };

            return View(entity);
        }

        [HttpPost]
        public ActionResult Exist(string departname, string systemTitle)
        {
            var result = this.DepartmentInfoManager.Get(departname,systemTitle) != null;

            return Json(new {IsSuccess = result.ToString()});
        }

        [HttpPost]
        public ActionResult Save(DepartmentInfo entity)
        {
            if (entity.ID == 0)
            {
                entity.CreateTime = DateTime.Now;

                this.DepartmentInfoManager.Save(entity);
            }
            else
            {
                var department = this.DepartmentInfoManager.Get(entity.ID);

                department.DepartName = entity.DepartName;
                department.PersonName = entity.PersonName;
                department.TelPhone = entity.TelPhone;
                department.Address = entity.Address;
                department.SystemTitle = entity.SystemTitle;
                department.CreateTime = DateTime.Now;

                this.DepartmentInfoManager.Update(department);
            }

            return Json(new { IsSuccess = true, Message = "保存成功" }, "text/html", JsonRequestBehavior.AllowGet);
        }

        // POST: /DepartmentInfo/Delete/5

        [HttpPost]
        [Authorize]
        public ActionResult Delete(IList<int> idList)
        {
            foreach (var item in idList)
            {
                IList<UserGroup> userGroups =
                    this.UserGroupManager.LoadAll().Where(p => p.DepartmentInfo.ID == item).ToList();

                if (userGroups.Count > 0)
                {
                    foreach (var userGroup in userGroups)
                    {
                        IList<UserInfo> userInfos =
                            this.UserInfoManager.LoadAll().Where(p => p.UserGroup.ID == userGroup.ID).ToList();

                        if (userInfos.Count > 0)
                        {
                            foreach (var userInfo in userInfos)
                            {
                                this.UserInfoManager.Delete(userInfo.ID);
                            }
                        }

                        IList<ColumnmenuPermissionsInfo> columnmenuPermissionsInfos =
                            this.ColumnmenuPermissionsInfoManager.LoadAll()
                                .Where(p => p.UserGroup.ID == userGroup.ID)
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
                                .Where(p => p.UserGroup.ID == userGroup.ID)
                                .ToList();


                        if (menuPermissionsInfos.Count > 0)
                        {
                            foreach (var menuPermissionsInfo in menuPermissionsInfos)
                            {
                                this.MenuPermissionsInfoManager.Delete(menuPermissionsInfo.ID);
                            }
                        }

                        this.UserGroupManager.Delete(userGroup.ID);
                    }
                }
    
            }
            this.DepartmentInfoManager.Delete(idList.Cast<object>().ToList());
            return Json(new { IsSuccess = true, Message = "删除成功" });
        }
    }
}
