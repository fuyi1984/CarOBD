using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using Domain;
using Service;

namespace CarOBDMvc.Controllers
{
    public class UserInfoController : Controller
    {
        public IUserInfoManager UserInfoManager { get; set; }

        public IDepartmentInfoManager DepartmentInfoManager { get; set; }

        public IUserGroupManager UserGroupManager { get; set; }

 

        //
        // GET: /UserInfo/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadAllByPage(int page, int rows, string order, string sort)
        {
            long total = 0;
            var list = this.UserInfoManager.LoadAllByPage(out total, page, rows, order, sort);

            var result = new
            {
                total = total,
                rows = (from p in list
                    select new
                    {
                        p.ID,
                        p.Name,
                        p.Account,
                        p.Password,
                        p.IsEnabled,
                        p.UserGroup.UserGroupName,
                        p.UserGroup.DepartmentInfo.DepartName,
                        p.CreateTime
                    }).ToList()
            };

            return Json(result);
        }

       
        
        //
        // GET: /UserInfo/Edit/5
 
        public ActionResult Edit(int id=0)
        {
            UserInfo entity = null;

            UserGroup usergroup = null;

         

            if (id != 0)
            {
                entity = this.UserInfoManager.Get(id);
            }

            usergroup = usergroup ?? new UserGroup()
            {
                UserGroupName = string.Empty,
                ID = 0
            };


          
            entity = entity ?? new UserInfo()
            {
                Name = string.Empty,
                Account = string.Empty,
                Password = string.Empty,
                IsEnabled = true,
                UserGroup = usergroup,
                ID = 0
            };

            
            ViewBag.Groups = this.UserGroupManager.LoadAll();

            return View(entity);
        }

        [HttpPost]
        public ActionResult Exist(string account)
        {
            var result = this.UserInfoManager.Get(account) != null;

            return Json(new { IsSuccess = result.ToString() });
        }

        [HttpPost]
        public ActionResult Save(FormCollection collection)
        {
      

            UserGroup ugentity = this.UserGroupManager.Get(int.Parse(collection["UserGroupID"]));

            if (int.Parse(collection["ID"]) == 0)
            {
                UserInfo uientity = new UserInfo();

                uientity.Name = collection["Name"];
                uientity.Account = collection["Account"];
                uientity.Password = EncodeHelper.DesEncrypt(collection["Password"]);
                uientity.IsEnabled = bool.Parse(collection["rdEnabled"]);

                uientity.UserGroup = ugentity;

                uientity.CreateTime = DateTime.Now;

                this.UserInfoManager.Save(uientity);

            }
            else
            {
               
                var rolentity = this.UserInfoManager.Get(int.Parse(collection["ID"]));

                rolentity.Name = collection["Name"];
                //rolentity.Account = collection["Accounts"];
                rolentity.Password = EncodeHelper.DesEncrypt(collection["Password"]);
                rolentity.IsEnabled = bool.Parse(collection["rdEnabled"]);

                rolentity.UserGroup = ugentity;

                rolentity.CreateTime = DateTime.Now;

                this.UserInfoManager.Update(rolentity);
            }

            return Json(new { IsSuccess = true, Message = "保存成功" }, "text/html", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(IList<int> idList)
        {
            this.UserInfoManager.Delete(idList.Cast<object>().ToList());
            return Json(new { IsSuccess = true, Message = "删除成功" });
        }
    }
}
