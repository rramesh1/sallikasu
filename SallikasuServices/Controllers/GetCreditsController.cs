using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SallikasuServices.Controllers
{
    public class GetCreditsController : Controller
    {
        // GET: GetCredits
        public ActionResult Index(String UserID)
        {
            decimal? TotalCredits;
            List<nastha_credits> CreditList;

            Models.GetCreditsModel tModel = new Models.GetCreditsModel();
            tModel.Process(UserID, out TotalCredits, out CreditList);
            String tJson = "{" + "\"TotalCredits\":\"" + TotalCredits.ToString() + "\"" + JsonConvert.SerializeObject(CreditList) + "}";
            return Json(tJson,JsonRequestBehavior.AllowGet);
        }
    }
}