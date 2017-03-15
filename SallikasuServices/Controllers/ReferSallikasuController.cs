using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SallikasuServices.Controllers
{
    public class ReferSallikasuController : Controller
    {
        // GET: ReferSallikasu
        public ActionResult Index(string userid, int merchantid, string ownercellphone)
        {
            Models.ReferSallikasuModel tModel = new Models.ReferSallikasuModel();
            tModel.Process(userid, merchantid, ownercellphone);
            return Json("{\"status\":\"ok\"}", JsonRequestBehavior.AllowGet);
        }
    }
}