using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SallikasuServices.Controllers
{
    public class GetMySubscriptionController : Controller
    {
        // GET: GetMySubscription
        public ActionResult Index(int userid,int merchantid)
        {
            Models.GetMySubscriptionModel tModel = new Models.GetMySubscriptionModel();
            List<Models.GetMySubscriptionData> tList;

            String tJson = "{\"status\":\"failed\"}";
            if (tModel.Process(userid,merchantid,  out tList))
            {
                
                tJson = "{\"status\":\"ok\"" + ",\"" +
                            JsonConvert.SerializeObject(tList)
                            + "}";
                
            }
            return Json(tJson, JsonRequestBehavior.AllowGet);
        }
    }
}