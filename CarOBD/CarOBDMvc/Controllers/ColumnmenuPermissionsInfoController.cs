using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Service;

namespace CarOBDMvc.Controllers
{
    public class ColumnmenuPermissionsInfoController : Controller
    {
        public IColumnmenuPermissionsInfoManager ColumnmenuPermissionsInfoManager { get; set; }

        public IColumnmenuInfoManager ColumnmenuInfoManager { get; set; }

        public IUserGroupManager UserGroupManager { get; set; }
        //
        // GET: /ColumnmenuPermissionsInfo/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadAllByPage(int page, int rows, string order, string sort)
        {
            long total = 0;
            var list = this.ColumnmenuPermissionsInfoManager.LoadAllByPage(out total, page, rows, order, sort);

            var result = new
            {
                total = total,
                rows = (from p in list
                    select
                        new
                        {
                            p.ID,
                            p.ColumnmenuInfo.MenuName,
                            p.UserGroup.UserGroupName,
                            p.CreateTime
                        }).ToList()
            };

            return Json(result);
        }



        public ActionResult Delete(IList<int> idList)
        {
            this.ColumnmenuPermissionsInfoManager.Delete(idList.Cast<object>().ToList());
            return Json(new { IsSuccess = true, Message = "删除成功" });
        }

        public ActionResult Edit(int id = 0)
        {
            ColumnmenuPermissionsInfo columnmenuPermissionsInfo = null;

            ColumnmenuInfo columnmenuInfo = null;

            UserGroup userGroup = null;

            if (id != 0)
            {
                columnmenuPermissionsInfo = this.ColumnmenuPermissionsInfoManager.Get(id);
            }

            columnmenuInfo = columnmenuInfo ?? new ColumnmenuInfo()
            {
                MenuName = string.Empty,
                MenuId = 0
            };


            userGroup = userGroup ?? new UserGroup()
            {
                UserGroupName = string.Empty,
                ID = 0
            };

            columnmenuPermissionsInfo = columnmenuPermissionsInfo ?? new ColumnmenuPermissionsInfo()
            {
                ColumnmenuInfo = columnmenuInfo,
                UserGroup = userGroup,
                ID=0
            };

            ViewBag.ColumnmenuInfo = this.ColumnmenuInfoManager.LoadAll();
            ViewBag.UserGroup = this.UserGroupManager.LoadAll();

            return View(columnmenuPermissionsInfo);
        }

        //[HttpPost]
        //public ActionResult Exist(string menuname)
        //{
        //    var result = this.ColumnmenuPermissionsInfoManager.Get(menuname) != null;

        //    return Json(new { IsSuccess = result.ToString() });
        //}



        [HttpPost]
        public ActionResult Save(FormCollection collection)
        {
            var usergroup = this.UserGroupManager.Get(int.Parse(collection["UserGroupID"]));

            var columnmenu = this.ColumnmenuInfoManager.Get(int.Parse(collection["ColumnmenuInfoID"]));

            if (int.Parse(collection["ID"]) == 0)
            {
                ColumnmenuPermissionsInfo columnmenuInfo = new ColumnmenuPermissionsInfo();

                columnmenuInfo.ColumnmenuInfo = columnmenu;

                columnmenuInfo.UserGroup = usergroup;

                columnmenuInfo.CreateTime = DateTime.Now;

                this.ColumnmenuPermissionsInfoManager.Save(columnmenuInfo);

            }
            else
            {

                var rolentity = this.ColumnmenuPermissionsInfoManager.Get(int.Parse(collection["ID"]));

                rolentity.ColumnmenuInfo = columnmenu;

                rolentity.UserGroup = usergroup;

                rolentity.CreateTime = DateTime.Now;

                this.ColumnmenuPermissionsInfoManager.Update(rolentity);
            }

            return Json(new { IsSuccess = true, Message = "保存成功" }, "text/html", JsonRequestBehavior.AllowGet);
        }

        
    }
}
