using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Domain;
namespace CarOBDMvc.Controllers
{
    public class Ca_AdvisoryactivitiesController : Controller
    {
        public ICa_AdvisoryactivitiesManager Ca_AdvisoryactivitiesManager { get; set; }

        public IUserInfoManager UserInfoManager { get; set; }

        //
        // GET: /Ca_Advisoryactivities/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadAllByPage(int page, int rows, string order, string sort)
        {
            var userInfo = this.UserInfoManager.Get(int.Parse(this.User.Identity.Name));

            long total = 0;
            var list = this.Ca_AdvisoryactivitiesManager.LoadAllByPage(out total, page, rows, order, sort,userInfo.UserGroup.UserGroupName);

            var result = new
            {
                total = total,
                rows = list
            };

            return Json(result);
        }
        public ActionResult Edit(int id = 0)
        {
            Ca_Advisoryactivities entity = null;

            if (id != 0)
            {
                entity = this.Ca_AdvisoryactivitiesManager.Get(id);
            }

            entity = entity ?? new Ca_Advisoryactivities()
            {
                Address = string.Empty,
                ActivityName = string.Empty,
                TelPhone = string.Empty,
                Context = string.Empty,
                BeginTime=DateTime.Now,
                EndTime = DateTime.Now,
                ID = 0
            };

            return View(entity);
        }

        [HttpPost]
        public ActionResult Exist(string activityname)
        {
            var result = this.Ca_AdvisoryactivitiesManager.Get(activityname) != null;

            return Json(new { IsSuccess = result.ToString() });
        }

        [HttpPost]
        public ActionResult Save(Ca_Advisoryactivities entity)
        {
            var userInfo = this.UserInfoManager.Get(int.Parse(this.User.Identity.Name));

            if (entity.ID == 0)
            {
                entity.CreateTime = DateTime.Now;
                entity.UserGroupName = userInfo.UserGroup.UserGroupName;
                this.Ca_AdvisoryactivitiesManager.Save(entity);
            }
            else
            {
                var Ca_Advisoryactivities = this.Ca_AdvisoryactivitiesManager.Get(entity.ID);

                Ca_Advisoryactivities.ActivityName = entity.ActivityName;
                Ca_Advisoryactivities.TelPhone = entity.TelPhone;
                Ca_Advisoryactivities.Address = entity.Address;
                Ca_Advisoryactivities.Context = entity.Context;
                Ca_Advisoryactivities.BeginTime = entity.BeginTime;
                Ca_Advisoryactivities.EndTime = entity.EndTime;
                Ca_Advisoryactivities.UserGroupName = userInfo.UserGroup.UserGroupName;
                Ca_Advisoryactivities.CreateTime = DateTime.Now;

                this.Ca_AdvisoryactivitiesManager.Update(Ca_Advisoryactivities);
            }

            return Json(new { IsSuccess = true, Message = "保存成功" }, "text/html", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(IList<int> idList)
        {
            this.Ca_AdvisoryactivitiesManager.Delete(idList.Cast<object>().ToList());
            return Json(new { IsSuccess = true, Message = "删除成功" });
        }
    }
}
