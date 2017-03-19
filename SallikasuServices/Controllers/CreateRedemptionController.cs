using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SallikasuServices.Controllers
{
    public class CreateRedemptionController : Controller
    {
        // GET: CreateRedemption
        public ActionResult Index(int userid, int merchantid, decimal AmountRedeemed)
        {
            Models.CreditRedemptionModel tModel = new Models.CreditRedemptionModel();
            String tJson = "{\"status\":\"failed\"}";
            if ( tModel.Process(userid,merchantid,AmountRedeemed) )
            {
                tJson = "{\"status\":\"ok\"}";
            }
            return Json(tJson, JsonRequestBehavior.AllowGet);
        }
    }
}