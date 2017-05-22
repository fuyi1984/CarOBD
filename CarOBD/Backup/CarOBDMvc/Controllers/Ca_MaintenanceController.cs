using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Service;

namespace CarOBDMvc.Controllers
{
    public class Ca_MaintenanceController : Controller
    {
        public ICa_MaintenanceManager Ca_MaintenanceManager { get; set; }

        public IUserInfoManager UserInfoManager { get; set; }

        //
        // GET: /Ca_Maintenance/

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult LoadAllByPage(int page, int rows, string order, string sort)
        {
            var userInfo = this.UserInfoManager.Get(int.Parse(this.User.Identity.Name));

            long total = 0;
            var list = this.Ca_MaintenanceManager.LoadAllByPage(out total, page, rows, order, sort,userInfo.UserGroup.UserGroupName);

            var result = new
            {
                total = total,
                rows = list
            };

            return Json(result);
        }


        public ActionResult Edit(int id = 0)
        {
            Ca_Maintenance entity = null;

            if (id != 0)
            {
                entity = this.Ca_MaintenanceManager.Get(id);
            }

            entity = entity ?? new Ca_Maintenance()
            {
                Address = string.Empty,
                RepairName = string.Empty,
                TelPhone = string.Empty,
                Des=string.Empty,
                ID = 0
            };

            return View(entity);
        }

        [HttpPost]
        public ActionResult Exist(string repairname)
        {
            var result = this.Ca_MaintenanceManager.Get(repairname) != null;

            return Json(new { IsSuccess = result.ToString() });
        }

        [HttpPost]
        public ActionResult Save(Ca_Maintenance entity)
        {
            var userInfo = this.UserInfoManager.Get(int.Parse(this.User.Identity.Name));

            if (entity.ID == 0)
            {
                entity.CreateTime = DateTime.Now;
                entity.UserGroupName = userInfo.UserGroup.UserGroupName;
                this.Ca_MaintenanceManager.Save(entity);
            }
            else
            {
                var ca_maintenance = this.Ca_MaintenanceManager.Get(entity.ID);

                ca_maintenance.RepairName = entity.RepairName;
                ca_maintenance.TelPhone = entity.TelPhone;
                ca_maintenance.Address = entity.Address;
                ca_maintenance.Des = entity.Des;
                ca_maintenance.UserGroupName = userInfo.UserGroup.UserGroupName;
                ca_maintenance.CreateTime = DateTime.Now;

                this.Ca_MaintenanceManager.Update(ca_maintenance);
            }

            return Json(new { IsSuccess = true, Message = "保存成功" }, "text/html", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(IList<int> idList)
        {
            this.Ca_MaintenanceManager.Delete(idList.Cast<object>().ToList());
            return Json(new { IsSuccess = true, Message = "删除成功" });
        }
    }
}
