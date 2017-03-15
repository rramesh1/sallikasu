using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SallikasuServices.Controllers
{
    public class GetSystemConfigController : Controller
    {
        // GET: GetSystemConfig
        public ActionResult Index(string Country, String ConfigType)
        {
            Models.GetSystemConfigModel tModel = new Models.GetSystemConfigModel();

            List<system_configs> tList = tModel.Get(Country,ConfigType);

            return Json(tList, JsonRequestBehavior.AllowGet);
        }
        
    }
}
