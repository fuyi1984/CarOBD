using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;

namespace CarOBDMvc.Controllers
{
    public class LogInfoController : Controller
    {
        public ILogInfoManager LogInfoManager { get; set; }
        //
        // GET: /LogInfo/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadAllByPage(int page, int rows, string order, string sort)
        {
            long total = 0;
            var list = this.LogInfoManager.LoadAllByPage(out total, page, rows, order, sort);

            var result = new
            {
                total = total,
                rows = list
            };

            return Json(result);
        }

        
    }
}
