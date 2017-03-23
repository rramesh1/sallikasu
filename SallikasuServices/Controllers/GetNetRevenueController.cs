using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SallikasuServices.Controllers
{
    public class GetNetRevenueController : Controller
    {
        // GET: GetNetRevenue
        public ActionResult Index(int userid, string start_mmyy, string end_mmyy,int merchantid=-1)
        {
            Models.GetNetRevenueModel tModel = new Models.GetNetRevenueModel();

            List<Models.GetNewRevenueData> tList;
            
            String tJson = "{\"status\":\"failed\"}";
            if ( tModel.Process(userid,start_mmyy, end_mmyy,merchantid,out tList))
            {
                tJson = "{\"status\":\"ok\"" + ",\"" +
                                JsonConvert.SerializeObject(tList)
                                + "}";
            }

            return Json(tJson, JsonRequestBehavior.AllowGet);
        }
    }
}