using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SallikasuServices.Controllers
{
    public class GetCommissionPaidByAdvertiserController : Controller
    {
        // GET: GetCommissionPaidByAdvertiser
        public ActionResult Index(int userid, string start_mmyy,  String end_mmyy, int merchantid=-1)
        {
            Models.GetCommissionPaidByAdvertiserModel tModel = new Models.GetCommissionPaidByAdvertiserModel();
            List<Models.GetCommissionPaidByAdvertiserData> tList;
            String tJson = "{\"status\":\"failed\"}";
            if (tModel.Process(userid, start_mmyy, end_mmyy, merchantid, out tList))
            {
                    tJson = "{\"status\":\"ok\"" + ",\"" +
                                JsonConvert.SerializeObject(tList)
                                + "}";
                

            }
            return Json(tJson, JsonRequestBehavior.AllowGet);
        }
    }
}