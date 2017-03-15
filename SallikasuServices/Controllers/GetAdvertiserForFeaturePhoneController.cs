using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SallikasuServices.Controllers
{
    public class GetAdvertiserForFeaturePhoneController : Controller
    {
        // GET: GetAdvertiserForFeaturePhone
        public ActionResult Get(String State,String City, String Sublocality, String Category)
        {
            Models.GetAdvertisersForFeaturePhoneModel tModel = new Models.GetAdvertisersForFeaturePhoneModel();
            List<merchant> tList = tModel.Process(State, City, Sublocality, Category);

            return Json(tList, JsonRequestBehavior.AllowGet);
        }
    }
}