using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Newtonsoft.Json;
using Service;
using Service.Implement;
using Spring.Context;
using Spring.Context.Support;
using WebService;
using System.Web;
using System.Web.Services;

namespace CarOBDMvc.Models
{
    [WebService(Namespace = "http://baidu.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(true)]
    public class PersonContract : System.Web.Services.WebService, IPersonContract
    {
        [WebMethod]
        public string GetData()
        {
            return "你输入的是：";
        }

        /// <summary>
        /// 获取维修保养信息
        /// </summary>
        /// <param name="username">验证用户</param>
        /// <param name="passworld">验证密码</param>
        /// <param name="city">城市</param>
        /// <returns>维修保养信息</returns>
        [WebMethod]
        public string GetCaMaintenance(string username, string passworld, string city)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();

            authentication auth = (authentication)cxt.GetObject("authentication");

            if (auth.UserName.Equals(username) && auth.PassWorld.Equals(passworld))
            {
                ICa_MaintenanceManager Ca_MaintenanceManager =
                    (ICa_MaintenanceManager) cxt.GetObject("Manager.Ca_Maintenance");

                IList<Ca_Maintenance> list =
                    Ca_MaintenanceManager.LoadAll().Where(p => p.Address.Contains(city)).ToList();

                return JsonConvert.SerializeObject(list);

            }
            else
            {
                return "用户验证失败";
            }
           
        }

        /// <summary>
        /// 获取年审信息
        /// </summary>
        /// <param name="username">验证用户</param>
        /// <param name="passworld">验证密码</param>
        /// <param name="city">城市</param>
        /// <returns>年审信息</returns>
        [WebMethod]
        public string GetCaVerification(string username, string passworld, string city)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();

            authentication auth = (authentication)cxt.GetObject("authentication");

            if (auth.UserName.Equals(username) && auth.PassWorld.Equals(passworld))
            {
                ICa_VerificationManager Ca_VerificationManager =
                    (ICa_VerificationManager)cxt.GetObject("Manager.Ca_Verification");

                IList<Ca_Verification> list =
                    Ca_VerificationManager.LoadAll().Where(p => p.Address.Contains(city)).ToList();

                return JsonConvert.SerializeObject(list);

            }
            else
            {
                return "用户验证失败";
            }

        }




        /// <summary>
        /// 获取咨询活动
        /// </summary>
        /// <param name="username">验证用户</param>
        /// <param name="passworld">验证密码</param>
        /// <param name="city">城市</param>
        /// <returns>咨询活动信息</returns>
        [WebMethod]
        public string GetCaAdvisoryactivities(string username, string passworld, string city)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();

            authentication auth = (authentication)cxt.GetObject("authentication");

            if (auth.UserName.Equals(username) && auth.PassWorld.Equals(passworld))
            {
                ICa_AdvisoryactivitiesManager Ca_AdvisoryactivitiesManager =
                    (ICa_AdvisoryactivitiesManager)cxt.GetObject("Manager.Ca_Advisoryactivities");

                IList<Ca_Advisoryactivities> list =
                     Ca_AdvisoryactivitiesManager.LoadAll().Where(p => p.Address.Contains(city)).ToList();

                return JsonConvert.SerializeObject(list);

            }
            else
            {
                return "用户验证失败";
            }
        }
    }
}
