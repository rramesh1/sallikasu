using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SallikasuServices.Controllers
{
    public class GetRegistrationCodeController : Controller
    {
        

        // POST: GetRegistrationCode/Create
        [HttpPost]
        public ActionResult Create(int MerchantId)
        {
            try
            {
                SallikasuServices.Models.RegistrationCodeModel tModel = new Models.RegistrationCodeModel();
                int tRegCode = tModel.Get(MerchantId);
                String tJson = "{\"RegistrationCode\":\"" + tRegCode + "\"}";
                return Json(tJson,JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("{\"RegistrationCode\":\"0\"}", JsonRequestBehavior.AllowGet); ;
            }
        }

        
    }
}
