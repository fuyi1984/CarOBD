using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Service;

namespace CarOBDMvc.Controllers
{
    public class Ca_VerificationController : Controller
    {
        public ICa_VerificationManager Ca_VerificationManager { get; set; }

        public IUserInfoManager UserInfoManager { get; set; }
        //
        // GET: /Ca_Verification/

        public ActionResult Index()
        {
            return View();
        }


        [Authorize]
        public ActionResult LoadAllByPage(int page, int rows, string order, string sort)
        {
            var userInfo = this.UserInfoManager.Get(int.Parse(this.User.Identity.Name));

            long total = 0;
            var list = this.Ca_VerificationManager.LoadAllByPage(out total, page, rows, order, sort, userInfo.UserGroup.UserGroupName);

            var result = new
            {
                total = total,
                rows = list
            };

            return Json(result);
        }


        public ActionResult Edit(int id = 0)
        {
            Ca_Verification entity = null;

            if (id != 0)
            {
                entity = this.Ca_VerificationManager.Get(id);
            }

            entity = entity ?? new Ca_Verification()
            {
                Address = string.Empty,
                RepairName = string.Empty,
                TelPhone = string.Empty,
                Des = string.Empty,
                ID = 0
            };

            return View(entity);
        }

        [HttpPost]
        public ActionResult Exist(string repairname)
        {
            var result = this.Ca_VerificationManager.Get(repairname) != null;

            return Json(new { IsSuccess = result.ToString() });
        }

        [HttpPost]
        public ActionResult Save(Ca_Verification entity)
        {
            var userInfo = this.UserInfoManager.Get(int.Parse(this.User.Identity.Name));

            if (entity.ID == 0)
            {
                entity.CreateTime = DateTime.Now;
                entity.UserGroupName = userInfo.UserGroup.UserGroupName;
                this.Ca_VerificationManager.Save(entity);
            }
            else
            {
                var ca_maintenance = this.Ca_VerificationManager.Get(entity.ID);

                ca_maintenance.RepairName = entity.RepairName;
                ca_maintenance.TelPhone = entity.TelPhone;
                ca_maintenance.Address = entity.Address;
                ca_maintenance.Des = entity.Des;
                ca_maintenance.UserGroupName = userInfo.UserGroup.UserGroupName;
                ca_maintenance.CreateTime = DateTime.Now;

                this.Ca_VerificationManager.Update(ca_maintenance);
            }

            return Json(new { IsSuccess = true, Message = "保存成功" }, "text/html", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(IList<int> idList)
        {
            this.Ca_VerificationManager.Delete(idList.Cast<object>().ToList());
            return Json(new { IsSuccess = true, Message = "删除成功" });
        }

    }
}
