using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SallikasuServices.Controllers
{
    public class GetRefererController : Controller
    {
        // GET: GetReferer
        public ActionResult Index(String Cellphone)
        {
            Models.GetRefererModel tModel = new Models.GetRefererModel();
            string tJson = "{\"Status\":\"ok\" \"result\":\"true\"}";
            if (tModel.Get(Cellphone)) 
               tJson =  "{\"Status\":\"ok\" \"result\":\"false\"}";
            return Json(tJson, JsonRequestBehavior.AllowGet);
        }

       
    }
}
