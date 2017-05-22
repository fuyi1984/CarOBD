using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Service;

namespace CarOBDMvc.Controllers
{
    public class MenuInfoController : Controller
    {
        public IMenuInfoManager MenuInfoManager { get; set; }

        public IColumnmenuInfoManager ColumnmenuInfoManager { get; set; }

        public IMenuPermissionsInfoManager MenuPermissionsInfoManager { get; set; }
        //
        // GET: /MenuInfo/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }


        public ActionResult LoadAllByPageDetail(int page, int rows, string order, string sort)
        {
            long total = 0;

            var list = this.MenuInfoManager.LoadAllByPage(out total, page, rows, order, sort);

            var result = new
            {
                total = total,
                rows = list
            };

            return Json(result);
        }

        public ActionResult LoadAllByPage(int page, int rows, string order, string sort)
        {
            long total = 0;

            var list = this.MenuInfoManager.LoadAllByPage(out total, page, rows, order, sort);

            var colalllist = this.ColumnmenuInfoManager.LoadAll();

            var result = new
            {
                total = total,
                rows = (from p in list
                        from q in colalllist
                        where q.MenuInfos.Contains(p)
                            select new
                            {
                                p.MenuId,
                                p.MenuNames,
                                p.Url,
                                p.Icon,
                                q.MenuName,
                                p.CreateTime
                            }).ToList()
            };

            return Json(result);
        }

        public ActionResult Del(IList<int> idList)
        {
            foreach (var item in idList)
            {
                var menu_entity = this.MenuInfoManager.Get(item);

                var columns_entity = this.ColumnmenuInfoManager.LoadAll();

                if (columns_entity.Count > 0)
                {

                    foreach (var columnmenuInfo in columns_entity)
                    {
                        if (columnmenuInfo.MenuInfos.Contains(menu_entity))
                        {
                            columnmenuInfo.MenuInfos.Remove(menu_entity);

                            this.ColumnmenuInfoManager.SaveOrUpdate(columnmenuInfo);
                        }
                    }
                }


                var menuper_entity =
                    this.MenuPermissionsInfoManager.LoadAll().Where(p => p.MenuInfo.MenuId == item).ToList();


                if (menuper_entity.Count > 0)
                {
                    foreach (var menuPermissionsInfo in menuper_entity)
                    {
                        this.MenuPermissionsInfoManager.Delete(menuPermissionsInfo.ID);
                    }
                }
            }

            this.MenuInfoManager.Delete(idList.Cast<object>().ToList());
            return Json(new {IsSuccess = true, Message = "删除成功"});
        }

        public ActionResult Delete(IList<int> idList)
        {
            foreach (var item in idList)
            {
                var menu_entity = this.MenuInfoManager.Get(item);

                var columns_entity = this.ColumnmenuInfoManager.LoadAll();

                var menuper_entity = this.MenuPermissionsInfoManager.LoadAll();

                foreach (var columnmenuInfo in columns_entity)
                {
                    if (columnmenuInfo.MenuInfos.Contains(menu_entity))
                    {
                        columnmenuInfo.MenuInfos.Remove(menu_entity);

                        this.ColumnmenuInfoManager.SaveOrUpdate(columnmenuInfo);
                    }
                }


                foreach (var menuPermissionsInfo in menuper_entity)
                {
                    if (menuPermissionsInfo.MenuInfo.MenuId == menu_entity.MenuId)
                    {
                        this.MenuPermissionsInfoManager.Delete(menuPermissionsInfo.ID);
                    }
                }
            }

            return Json(new { IsSuccess = true, Message = "删除成功" });
        }

        public ActionResult Edit(int id = 0)
        {
            //ColumnmenuInfo columnmenuInfo = null;

            MenuInfo menuInfo = null;

            if (id != 0)
            {
                menuInfo = this.MenuInfoManager.Get(id);
            }

            menuInfo = menuInfo ?? new MenuInfo()
            {
                MenuId = 0,
                MenuNames = string.Empty,
                Icon = string.Empty,
                Url = string.Empty
            };

            //columnmenuInfo = columnmenuInfo ?? new ColumnmenuInfo()
            //{
            //    MenuName = string.Empty,
            //    Icon = string.Empty,
            //    MenuId = 0,
            //    MenuInfos = new List<MenuInfo>()
            //    {
            //        menuInfo
            //    }
            //};


            //ViewBag.ColumnmenInfo = this.ColumnmenuInfoManager.LoadAll();

            return View(menuInfo);
        }

        [HttpPost]
        public ActionResult Exist(string menuname)
        {
            var result = this.MenuInfoManager.Get(menuname) != null;

            return Json(new { IsSuccess = result.ToString() });
        }

        public ActionResult feiPei()
        {
            ViewBag.MenuInfo = this.MenuInfoManager.LoadAll();

            ViewBag.Column = this.ColumnmenuInfoManager.LoadAll();

            return View();
        }

        [HttpPost]
        public ActionResult FeiPei(int menuId,int columnId)
        {
            var menu = this.MenuInfoManager.Get(menuId);

            var column = this.ColumnmenuInfoManager.Get(columnId);

            if (!column.MenuInfos.Contains(menu))
            {
                column.MenuInfos.Add(menu);
            }

            this.ColumnmenuInfoManager.SaveOrUpdate(column);

            return Json(new { IsSuccess = true, Message = "分配成功" }, "text/html", JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        public ActionResult Save(FormCollection collection)
        {
            //ColumnmenuInfo columnmenuInfo = this.ColumnmenuInfoManager.Get(int.Parse(collection["ColumnmenuInfoID"]));

            if (int.Parse(collection["ID"]) == 0)
            {
                MenuInfo menuInfo=new MenuInfo();

                menuInfo.MenuNames = collection["MenuNames"];

                menuInfo.Icon = collection["Icon"];

                menuInfo.Url = collection["Url"];

                menuInfo.CreateTime = DateTime.Now;

                //columnmenuInfo.MenuInfos.Add(menuInfo);
                
                //this.ColumnmenuInfoManager.SaveOrUpdate(columnmenuInfo);

                this.MenuInfoManager.Save(menuInfo);

                //columnmenuInfo.MenuInfos.Add(menuInfo);

                //this.ColumnmenuInfoManager.SaveOrUpdate(columnmenuInfo);

                

            }
            else
            {

                var rolentity = this.MenuInfoManager.Get(int.Parse(collection["ID"]));

                rolentity.MenuNames = collection["MenuNames"];

                rolentity.Icon = collection["Icon"];

                rolentity.Url = collection["Url"];

                rolentity.CreateTime = DateTime.Now;

                this.MenuInfoManager.Update(rolentity);

                //columnmenuInfo.MenuInfos.Add(rolentity);

                //this.ColumnmenuInfoManager.SaveOrUpdate(columnmenuInfo);
            }

            return Json(new { IsSuccess = true, Message = "保存成功" }, "text/html", JsonRequestBehavior.AllowGet);
        }
    }
}
