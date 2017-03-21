using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SallikasuServices.Controllers
{
    public class GetCommissionPaidByAdvertiserController : Controller
    {
        // GET: GetCommissionPaidByAdvertiser
        public ActionResult Index(int userid, DateTime start_date, DateTime end_date, int merchantid)
        {
            String tJson = "{\"status\":\"failed\"}";
            if (tModel.Process(userid, StartDate, EndDate, out tTotalRedeemed, out tList))
            {
                if (tTotalRedeemed != null && tTotalRedeemed != 0 && tList.Count > 0)
                {
                    tJson = "{\"status\":\"ok\"" + ",\"" +
                                "total_redeemed\":\"" + tTotalRedeemed.Value.ToString() + "\"," +
                                JsonConvert.SerializeObject(tList)
                                + "}";
                }

            }
            return Json(tJson, JsonRequestBehavior.AllowGet);
        }
    }
}