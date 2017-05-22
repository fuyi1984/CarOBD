using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Service;

namespace CarOBDMvc.Controllers
{
    public class ColumnmenuInfoController : Controller
    {
        public IColumnmenuInfoManager ColumnmenuInfoManager { get; set; }

        public IColumnmenuPermissionsInfoManager ColumnmenuPermissionsInfoManager { get; set; }

        public IMenuInfoManager MenuInfoManager { get; set; }

        //
        // GET: /ColumnmenuInfo/

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult LoadAllByPage(int page, int rows, string order, string sort)
        {
            long total = 0;
            var list = this.ColumnmenuInfoManager.LoadAllByPage(out total, page, rows, order, sort);

            var result = new
            {
                total = total,
                rows = list
            };

            return Json(result);
        }

        public ActionResult Delete(IList<int> idList)
        {
            

            foreach (var item in idList)
            {
                ColumnmenuInfo entity = this.ColumnmenuInfoManager.Get(item);

                var menusentity = this.MenuInfoManager.LoadAll();

                var columnperentity = this.ColumnmenuPermissionsInfoManager.LoadAll();

                foreach (var menus in menusentity)
                {
                    if (entity.MenuInfos.Contains(menus))
                    {
                        entity.MenuInfos.Remove(menus);
                    }
                }

                foreach (var columnmenuPermissionsInfo in columnperentity)
                {
                    if (columnmenuPermissionsInfo.ColumnmenuInfo.MenuId == entity.MenuId)
                    {
                        this.ColumnmenuPermissionsInfoManager.Delete(columnmenuPermissionsInfo.ID);
                    }
                }

                this.ColumnmenuInfoManager.SaveOrUpdate(entity);

                this.ColumnmenuInfoManager.Delete(entity.MenuId);

            }

            

            //this.ColumnmenuInfoManager.Delete(idList.Cast<object>().ToList());
            return Json(new { IsSuccess = true, Message = "删除成功" });
        }

        public ActionResult Edit(int id = 0)
        {
            ColumnmenuInfo columnmenuInfo = null;

            if (id != 0)
            {
                columnmenuInfo = this.ColumnmenuInfoManager.Get(id);
            }

       
            columnmenuInfo = columnmenuInfo ?? new ColumnmenuInfo()
            {
                MenuName =string.Empty,
                Icon = string.Empty,
                MenuId = 0
            };

            return View(columnmenuInfo);
        }

        [HttpPost]
        public ActionResult Exist(string menuname)
        {
            var result = this.ColumnmenuInfoManager.Get(menuname) != null;

            return Json(new { IsSuccess = result.ToString() });
        }



        [HttpPost]
        public ActionResult Save(FormCollection collection)
        {

            if (int.Parse(collection["ID"]) == 0)
            {
                ColumnmenuInfo columnmenuInfo=new ColumnmenuInfo();

                columnmenuInfo.MenuName = collection["MenuName"];

                columnmenuInfo.Icon = collection["Icon"];

                columnmenuInfo.CreateTime = DateTime.Now;

                this.ColumnmenuInfoManager.Save(columnmenuInfo);

            }
            else
            {

                var rolentity = this.ColumnmenuInfoManager.Get(int.Parse(collection["ID"]));

                rolentity.MenuName = collection["MenuName"];

                rolentity.Icon = collection["Icon"];

                rolentity.CreateTime = DateTime.Now;

                this.ColumnmenuInfoManager.Update(rolentity);
            }

            return Json(new { IsSuccess = true, Message = "保存成功" }, "text/html", JsonRequestBehavior.AllowGet);
        }
    }
}
