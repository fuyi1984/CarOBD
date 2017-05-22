using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Service;

namespace CarOBDMvc.Controllers
{
    public class MenuPermissionsInfoController : Controller
    {
        public IMenuPermissionsInfoManager MenuPermissionsInfoManager { get; set; }

        public IMenuInfoManager MenuInfoManager { get; set; }

        public IUserGroupManager UserGroupManager { get; set; }
        //
        // GET: /MenuPermissionsInfo/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadAllByPage(int page, int rows, string order, string sort)
        {
            long total = 0;
            var list = this.MenuPermissionsInfoManager.LoadAllByPage(out total, page, rows, order, sort);

            var result = new
            {
                total = total,
                rows = (from p in list
                        select
                            new
                            {
                                p.ID,
                                p.MenuInfo.MenuNames,
                                p.UserGroup.UserGroupName,

                                p.CreateTime
                            }).ToList()
            };

            return Json(result);
        }


        public ActionResult Delete(IList<int> idList)
        {
            this.MenuPermissionsInfoManager.Delete(idList.Cast<object>().ToList());
            return Json(new { IsSuccess = true, Message = "删除成功" });
        }

        public ActionResult Edit(int id = 0)
        {
            MenuPermissionsInfo menuPermissionsInfo = null;

            MenuInfo menuInfo = null;

            UserGroup userGroup = null;

            if (id != 0)
            {
                menuPermissionsInfo = this.MenuPermissionsInfoManager.Get(id);
            }

            menuInfo = menuInfo ?? new MenuInfo()
            {
                MenuNames = string.Empty,
                MenuId = 0
            };


            userGroup = userGroup ?? new UserGroup()
            {
                UserGroupName = string.Empty,
                ID = 0
            };

            menuPermissionsInfo = menuPermissionsInfo ?? new MenuPermissionsInfo()
            {
                MenuInfo = menuInfo,
                UserGroup = userGroup,
                ID = 0
            };

            ViewBag.MenuInfo = this.MenuInfoManager.LoadAll();
            ViewBag.UserGroup = this.UserGroupManager.LoadAll();

            return View(menuPermissionsInfo);
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

            var menu = this.MenuInfoManager.Get(int.Parse(collection["MenuID"]));

            if (int.Parse(collection["ID"]) == 0)
            {
                MenuPermissionsInfo menuPermissionsInfo = new MenuPermissionsInfo();

                menuPermissionsInfo.MenuInfo = menu;

                menuPermissionsInfo.UserGroup = usergroup;

                menuPermissionsInfo.CreateTime = DateTime.Now;

                this.MenuPermissionsInfoManager.Save(menuPermissionsInfo);

            }
            else
            {

                var rolentity = this.MenuPermissionsInfoManager.Get(int.Parse(collection["ID"]));

                rolentity.MenuInfo = menu;

                rolentity.UserGroup = usergroup;

                rolentity.CreateTime = DateTime.Now;

                this.MenuPermissionsInfoManager.Update(rolentity);
            }

            return Json(new { IsSuccess = true, Message = "保存成功" }, "text/html", JsonRequestBehavior.AllowGet);
        }
        
    }
}
