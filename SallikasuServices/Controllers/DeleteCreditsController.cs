using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SallikasuServices.Controllers
{
    public class DeleteCreditsController : Controller
    {
        // GET: DeleteCredits
        public ActionResult Index(int userid, decimal CreditRemaining)
        {
            Models.DeleteCreditsModel tModel = new Models.DeleteCreditsModel();

            string tJson= tJson = "{\"status\":\"failed\"}";
            if ( tModel.Process(userid, CreditRemaining))
                tJson = "{\"status\":\"ok\"}";

            return Json(tJson, JsonRequestBehavior.AllowGet);
        }
    }
}