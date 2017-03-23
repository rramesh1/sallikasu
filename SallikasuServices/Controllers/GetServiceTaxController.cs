using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SallikasuServices.Controllers
{
    public class GetServiceTaxController : Controller
    {
        // GET: GetServiceTax
        public ActionResult Index(int userid, int month,int year)
        {
            Models.GetServiceTaxModel tModel = new Models.GetServiceTaxModel();
            decimal tCumm_service_tax ;

            String tJson = "{\"status\":\"failed\"}";
            if (tModel.Process(userid,month,year,out tCumm_service_tax))
            {
                tJson = "{\"status\":\"ok\""+ "\"cumulative_service_tax\":\""+tCumm_service_tax.ToString() +"\"}";
            }
            return Json(tJson,JsonRequestBehavior.AllowGet);
        }
    }
}