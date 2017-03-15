using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SallikasuServices.Controllers
{
    public class GenerateTokenController : Controller
    {
        // GET: GenerateToken
        public ActionResult Index(int userid, int advertiserid, string cellNumber)
        {
            Models.GenerateTokenModel tModel = new Models.GenerateTokenModel();

            int tToken = tModel.process(userid, advertiserid, cellNumber);
            string tJson = "{\"status\":\"ok\", \"Token\":\"" + tToken + "\"}";
            return Json(tJson, JsonRequestBehavior.AllowGet);
        }
    }
}