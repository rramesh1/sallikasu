using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SallikasuServices.Controllers
{
    public class GetSubscriptionsByAllAdvertiserController : Controller
    {
        // GET: GetSubscriptionsByAllAdvertiser
        public ActionResult Index(int userid)
        {
            Models.GetSubscriptionByAllAdvertiserModel tModel = new Models.GetSubscriptionByAllAdvertiserModel();
            List<Models.GetSubscriptionsByAllAdvertiserData> tList; 
            String tJson = "{\"status\":\"failed\"}";
            if (tModel.Process(userid, out tList))
            {
                
                tJson = "{\"status\":\"ok\"" + ",\"" +
                            JsonConvert.SerializeObject(tList)
                            + "}";
                
            }
            return Json(tJson, JsonRequestBehavior.AllowGet);
            return View();
        }
    }
}