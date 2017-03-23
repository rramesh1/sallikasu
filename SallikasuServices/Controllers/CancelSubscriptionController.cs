using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SallikasuServices.Controllers
{
    public class CancelSubscriptionController : Controller
    {
        // GET: CancelSubscription
        public ActionResult Index(int userid, int merchantid)
        {
            Models.CancelSubscriptionModel tModel = new Models.CancelSubscriptionModel();

            String tJson = "{\"status\":\"failed\"}";
            if ( tModel.Process(userid,merchantid))
            {

                 tJson = "{\"status\":\"ok\"}";
            }
            return Json(tJson,JsonRequestBehavior.AllowGet);
        }
    }
}