using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SallikasuServices.Models;
using Newtonsoft.Json;

namespace SallikasuServices.Controllers
{
    public class GetOrganicMerchantController : Controller
    {
        // GET: GetOrganicMerchant
        public ActionResult Index(String State,String City, String BusinessType, String MerchantName )
        {
            GetOrganicMerchantModel tModel = new GetOrganicMerchantModel();
            List<merchant> tList = tModel.Get(State, City, BusinessType, MerchantName);
            string tJson = JsonConvert.SerializeObject(tList);
            return Json(tJson,JsonRequestBehavior.AllowGet);
        }

    }
}
