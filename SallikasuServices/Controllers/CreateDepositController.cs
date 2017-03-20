using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SallikasuServices.Controllers
{
    public class CreateDepositController : Controller
    {
        // GET: CreateDeposit
        [HttpPost]
        public ActionResult Index(int merchantid, decimal amount_deposit)
        {
            Models.CreateDepositModel tModel = new Models.CreateDepositModel();
            String tJson = "{\"status\":\"ok\"}";
            if ( !tModel.Process(merchantid,amount_deposit) )
            {
                tJson = "{\"status\":\"failed\"}";
            }
            return Json(tJson, JsonRequestBehavior.AllowGet);
        }
    }
}