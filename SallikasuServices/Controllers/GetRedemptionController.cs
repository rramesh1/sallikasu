using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SallikasuServices.Controllers
{
    public class GetRedemptionController : Controller
    {
        // GET: GetRedemption
        public ActionResult Index(int userid, DateTime StartDate, DateTime EndDate)
        {
            Models.GetRedemptionModel tModel = new Models.GetRedemptionModel();
            decimal? tTotalRedeemed;
            List<Models.GetRedemptionData> tList;
            String tJson = "{\"status\":\"failed\"}";
            if ( tModel.Process(userid, StartDate, EndDate, out tTotalRedeemed, out tList) )
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